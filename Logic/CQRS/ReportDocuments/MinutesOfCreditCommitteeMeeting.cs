using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.ReportDocuments.DTOs;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.ReportDocuments
{
    public class MinutesOfCreditCommitteeMeeting
    {
        public class Query : IRequest<Response<CreditCommitteeMeetingDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<CreditCommitteeMeetingDto>>
        {
            private readonly DataContext _dataContext;
            private readonly UserManager<AppUser> _userManager;

            public QueryHandler(DataContext dataContext, UserManager<AppUser> userManager)
            {
                _dataContext = dataContext;
                _userManager = userManager;
            }

            public async Task<Response<CreditCommitteeMeetingDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var loanApplication = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanHistoryStatus)
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationId);
                if (loanApplication == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (loanApplication.DicLoanHistoryStatus.Code != "Completed")
                    throw new RestException(HttpStatusCode.NotFound, "Заявка еще не завершена");

                var organization = await GetOrganizationAsync(loanApplication.Id);
                var result = new CreditCommitteeMeetingDto()
                {
                    ProtocolNumber = loanApplication.RegNumber, // TODO: Change it to normal number
                    Region = organization.Personality.DicRegion.NameRu,
                    City = $"г. {organization.Personality.DicRegion.AdministrativeCenterRu}",
                    ApplicantName = organization.Personality.FullName,
                    ApplicantAddress = organization.Personality.Address.Register,
                };

                var creditManager = await _dataContext.LoanApplicationTasks
                                        .Where(lat => lat.ApplicationId == loanApplication.Id && lat.Role.Value == RoleType.CreditManager)
                                        .Include(lat => lat.User)
                                            .ThenInclude(u => u.Profile)
                                        .Include(lat => lat.User)
                                            .ThenInclude(u => u.Branches)
                                                .ThenInclude(b => b.Branch)
                                                    .ThenInclude(b => b.Region)
                                        .Include(lat => lat.User)
                                            .ThenInclude(u => u.Branches)
                                                .ThenInclude(b => b.Position)
                                        .Select(x => x.User)
                                        .FirstOrDefaultAsync();
                if (creditManager == null)
                    throw new RestException(HttpStatusCode.NotFound, "Кредитный менеджер не найден");

                var creditManagerBranch = creditManager.Branches.FirstOrDefault(ub => ub.BranchId == loanApplication.BranchId);
                if (creditManagerBranch == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Кредитный менеджер не связан с филиалом заявки");
                }

                result.Reporter = new MemberDto
                {
                    Fullname = creditManager.Profile.GetFullName(),
                    Position = $"{creditManagerBranch.Position?.GetName()} филиала АО «КазАгроФинанс» по {creditManagerBranch.Branch.Region?.GetName()}"
                };

                var rolesList = await GetRolesAsync();
                var tasksList = await _dataContext.LoanApplicationTasks
                    .Include(x => x.User)
                        .ThenInclude(x => x.Branches)
                            .ThenInclude(x => x.Position)
                    .Include(x => x.User)
                        .ThenInclude(x => x.Profile)
                    .Include(x => x.DicTaskStatus)
                    .Where(x => x.ApplicationId == loanApplication.Id
                        && (x.DicTaskStatus.Code == "Completed" || x.DicTaskStatus.Code == "Rejected")
                        && rolesList.Select(x => x.Id).Contains(x.RoleId.Value))
                    .OrderBy(x => x.ModifiedDate)
                    .ToListAsync();

                var committeeRoles = rolesList.Where(x => x.Value == RoleType.CreditCommittee).Select(x => x.Id);
                var voteTasksList = tasksList.Where(x => committeeRoles.Contains(x.RoleId.Value));
                if (!voteTasksList.Any())
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Голосование еще не проведено");
                }

                result.LastVotedDate = voteTasksList.Last().ModifiedDate?.ToString("«dd» MMMM yyyyг.", new CultureInfo("ru-RU"));

                // TODO: Select exact Presided person after implementing it
                foreach (var (index, task) in voteTasksList.Select((task, index) => (index, task)))
                {
                    if (index == 0)
                    {
                        result.Presided = new MemberDto
                        {
                            Fullname = task.User.Profile.GetShortName(),
                            Position = task.User.Branches.FirstOrDefault(ub => ub.BranchId == loanApplication.BranchId)?.Position?.GetName(),
                            Decision = task.DicTaskStatus.Code == "Completed",
                            Comment = task.Comment
                        };
                    }
                    else
                    {
                        result.CreditCommitteeMembers.Add(new MemberDto
                        {
                            Fullname = task.User.Profile.GetShortName(),
                            Position = task.User.Branches.FirstOrDefault(ub => ub.BranchId == loanApplication.BranchId)?.Position?.GetName(),
                            Decision = task.DicTaskStatus.Code == "Completed",
                            Comment = task.Comment
                        });
                    }
                }

                var juristRole = rolesList.First(x => x.Value == RoleType.Jurist);
                var juristTask = tasksList.LastOrDefault(x => x.RoleId.Value == juristRole.Id);
                if (juristTask == null)
                    throw new RestException(HttpStatusCode.BadRequest, "Юридический отдел еще не обработал заявку");
                result.LegalDepartmentConclusion = juristTask.DicTaskStatus.Code == "Completed";

                var securityManagerRole = rolesList.First(x => x.Value == RoleType.Jurist);
                var securityManagerTask = tasksList.LastOrDefault(x => x.RoleId.Value == securityManagerRole.Id);
                if (securityManagerTask == null)
                    throw new RestException(HttpStatusCode.BadRequest, "Отдел безопасности еще не обработал заявку");
                result.SecurityDepartmentConclusion = securityManagerTask.DicTaskStatus.Code == "Completed";

                var riskManagerRole = rolesList.First(x => x.Value == RoleType.Jurist);
                var riskManagerTask = tasksList.LastOrDefault(x => x.RoleId.Value == riskManagerRole.Id);
                if (riskManagerTask == null)
                    throw new RestException(HttpStatusCode.BadRequest, "Отдел управления рисками еще не обработал заявку");
                result.RiskManagementDepartmentConclusion = riskManagerTask.DicTaskStatus.Code == "Completed";

                result.ProvidedConditions = result.RequestedConditions = await GetRequestedConditionsAsync(loanApplication.Id, result.Region);

                return Response.Success("Данные для протокола кредитного коммитета успешно сформированы", result);
            }

            private async Task<Organization> GetOrganizationAsync(Guid loanApplicationId)
            {
                var organizationQueryable = from o in _dataContext.Organizations
                                        .Include(x => x.Personality).ThenInclude(p => p.Address)
                                        .Include(x => x.Personality).ThenInclude(p => p.DicRegion)
                                            join dp in _dataContext.LoanApplicationDetailsPersonalities on o.PersonalityId equals dp.PersonalityId
                                            join d in _dataContext.LoanApplicationDetails on dp.DetailsId equals d.Id
                                            where d.LoanApplicationId == loanApplicationId
                                             && dp.PersonalityType == PersonalityTypeEnum.Organization
                                            select o;

                var organization = await organizationQueryable.FirstOrDefaultAsync();
                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                return organization;
            }

            private async Task<List<Role>> GetRolesAsync()
            {
                var rolesEnumList = new RoleType[] {
                    RoleType.Jurist, RoleType.RiskManager,
                    RoleType.SecurityManager, RoleType.CreditCommittee
                };

                return await _dataContext.Roles
                    .Where(x => !x.IsDeleted && rolesEnumList.Contains(x.Value))
                    .ToListAsync();
            }

            private async Task<ConditionDto> GetRequestedConditionsAsync(Guid loanApplicationId, string region)
            {
                var contracts = await _dataContext.Contracts
                        .Include(x => x.Calculator)
                        .Include(x => x.SelectedTechnic)
                            .ThenInclude(xx => xx.DicTechModel)
                                .ThenInclude(xx => xx.DicTechProduct)
                                    .ThenInclude(xxx => xxx.DicTechType)
                        .Include(x => x.SelectedAccessories)
                            .ThenInclude(xx => xx.DicTechModel)
                        .Where(x => x.LoanApplicationId == loanApplicationId)
                        .Select((x) => new
                        {
                            Technic = new
                            {
                                x.SelectedTechnic.Count,
                                Model = x.SelectedTechnic.DicTechModel.GetName(),
                                Provider = x.SelectedTechnic.DicProvider.GetName(),
                            },
                            x.Calculator,
                            Accessories = x.SelectedAccessories.Where(a => !a.IsDeleted).Select(a => new
                            {
                                a.Count,
                                Provider = a.DicProvider.GetName(),
                                TechModel = a.DicTechModel.GetName(),
                            })
                        })
                        .OrderBy(x => x.Calculator.CoFinancing)
                        .ThenBy(x => x.Calculator.Period)
                        .ToListAsync();

                if (!contracts.Any())
                    throw new RestException(HttpStatusCode.NotFound, "Контракты не найдены");

                return new ConditionDto
                {
                    CreditProduct = "Финансовый лизинг в рамках продукта «Экспресс-лизинг»", // TODO: Get lizing type when standard lizing will be implemented
                    Rate = "Согласно условиям финансирования, действующим на момент заключения Договора финансового лизинга",
                    Indexing = "Нет", // TODO: Get from somewhere
                    MonitoringFrequency = "Согласно требований внутренних нормативных документов",
                    Insurance = "Согласно требований внутренних нормативных документов",
                    ProjectReviewCommission = "Нет", // TODO: Get from somewhere
                    SpecialCondition = "Нет", // TODO: Get from somewhere
                    DeliveryPoint = region, 
                    ProfitCenter = region,

                    LizingSubject = contracts.Count > 1
                        ? contracts.Select((contract, index) => $"{index + 1}. {contract.Technic.Model} - {contract.Technic.Count} ед.").ToList()
                        : contracts.Select(contract => $"{contract.Technic.Model} - {contract.Technic.Count} ед.").ToList(),
                    Supplier = contracts.Count > 1
                        ? contracts.Select((contract, index) => $"{index + 1}. {contract.Technic.Provider}").ToList()
                        : contracts.Select(contract => $"{contract.Technic.Provider}").ToList(),
                    FinanceSource = "Внебюджетные средства", // TODO: Add dictionary
                    Sum = contracts.Sum(contract => contract.Calculator.Sum),
                    CoFinancing = contracts.Count > 1
                        ? contracts
                            .Select((contract, index) => new { Index = index + 1, contract.Calculator.CoFinancing })
                            .GroupBy(contract => contract.CoFinancing)
                            .Select(group => $"{string.Join("-", group.Select(g => $"{g.Index}."))} {Convert.ToInt32(group.Key)}% от общей стоимости предмета лизинга").ToList()
                        : contracts
                            .Select(contract => $"{Convert.ToInt32(contract.Calculator.CoFinancing)}% от общей стоимости предмета лизинга").ToList(),
                    Period = contracts.Count > 1
                        ? contracts
                            .Select((contract, index) => new { Index = index + 1, contract.Calculator.Period })
                            .GroupBy(contract => contract.Period)
                            .Select(group => $"{string.Join("-", group.Select(g => $"{g.Index}."))} до {group.Key} месяцев").ToList()
                        : contracts
                            .Select(contract => $"до {contract.Calculator.Period} месяцев").ToList(),
                    RewardsRepaymentProcedure = "Ежеквартально по 10 числам месяца. Начисление вознаграждения осуществляется с момента передачи первой части Предмета лизинга", // TODO: Get day of month
                    PrincipalDebtRepaymentProcedure = "Равными долями, 1 раз в год по 10 февраля года, начиная с 10 февраля 2022 года" // TODO: Get day of month and year
                };
            }
        }
    }
}
