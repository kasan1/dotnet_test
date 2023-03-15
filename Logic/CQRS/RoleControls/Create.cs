using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.RoleControls
{
    public class Create
    {
        public class CreateCommand : IRequest<Response<Unit>>
        {
            public RoleType Role { get; set; }
        }

        public class QueryHandler : IRequestHandler<CreateCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;

            public QueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                switch (request.Role)
                {
                    case RoleType.ComplianceManager:
                        await GenerateComplianceManager();
                        break;
                    case RoleType.RiskManager:
                        await GenerateRiskManager();
                        break;
                    case RoleType.CreditManager:
                        await GenerateCreditManagerAfterRiskManager();
                        await GenerateCreditManagerAfterCommittee();
                        break;
                    case RoleType.Logist:
                        await GenerateLogist();
                        break;
                    default:
                        throw new RestException(HttpStatusCode.BadRequest, "Роль не найден");
                }

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }

            private async Task<bool> GenerateLogist()
            {
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Value == RoleType.Logist);
                if (role == null)
                    throw new Exception();

                var statuses = await _dataContext.DicLoanHistoryStatuses.ToListAsync();

                var appStatus = statuses.FirstOrDefault(x => x.Code == "Expertise");
                if (appStatus == null)
                    throw new Exception();

                if (await _dataContext.RoleControls.AnyAsync(x => x.RoleId == role.Id && x.LoanHistoryStatusId == appStatus.Id))
                    return true;

                var taskStatuses = await _dataContext.DicTaskStatuses.ToListAsync();

                var roleControlId = Guid.NewGuid();
                await _dataContext.RoleControls.AddAsync(new Shared.Data.Context.RoleControls
                {
                    Id = roleControlId,
                    RoleId = role.Id,
                    LoanHistoryStatusId = appStatus.Id,
                    NameRu = "Логист",
                    NameKk = "Логист"
                });

                await _dataContext.RoleControlsFields.AddAsync(new RoleControlsField
                {
                    NameRu = "Соответствие проекта требованиям Логиста",
                    NameKk = "Соответствие проекта требованиям Логиста",
                    RoleControlId = roleControlId
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "InWork").Id,
                    NameRu = "На доработку",
                    NameKk = "На доработку",
                    IsApply = false,
                    HasForm = false,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "Пожалуйста укажите причину доработки в замечаниях",
                    DialogTitleRu = "Вы уверены что хотите отправить заявку на доработку?"
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "Completed").Id,
                    NameRu = "Готово",
                    NameKk = "Дайын",
                    IsApply = true,
                    HasForm = true,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "",
                    DialogTitleRu = "Вы уверены что заявка проходит по всем требованиям?"
                });

                await _dataContext.SaveChangesAsync();


                return true;
            }

            private async Task<bool> GenerateRiskManager()
            {
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Code == "RiskManager");
                if (role == null)
                    throw new Exception();

                var statuses = await _dataContext.DicLoanHistoryStatuses.ToListAsync();

                var appStatus = statuses.FirstOrDefault(x => x.Code == "RiskManager");
                if (appStatus == null)
                    throw new Exception();

                if (await _dataContext.RoleControls.AnyAsync(x => x.RoleId == role.Id && x.LoanHistoryStatusId == appStatus.Id))
                    return true;

                var taskStatuses = await _dataContext.DicTaskStatuses.ToListAsync();

                var roleControlId = Guid.NewGuid();
                await _dataContext.RoleControls.AddAsync(new Shared.Data.Context.RoleControls
                {
                    Id = roleControlId,
                    RoleId = role.Id,
                    LoanHistoryStatusId = appStatus.Id,
                    NameRu = "Риск менеджер",
                    NameKk = "Риск менеджер"
                });

                await _dataContext.RoleControlsFields.AddAsync(new RoleControlsField
                {
                    NameRu = "Соответствие проекта требованиям Рисковика",
                    NameKk = "Соответствие проекта требованиям Рисковика",
                    RoleControlId = roleControlId
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "InWork").Id,
                    NameRu = "На доработку",
                    NameKk = "На доработку",
                    IsApply = false,
                    HasForm = false,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "Пожалуйста укажите причину доработки в замечаниях",
                    DialogTitleRu = "Вы уверены что хотите отправить заявку на доработку?"
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "Completed").Id,
                    NameRu = "Готово",
                    NameKk = "Дайын",
                    IsApply = true,
                    HasForm = true,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "",
                    DialogTitleRu = "Вы уверены что заявка проходит по всем требованиям?"
                });

                await _dataContext.SaveChangesAsync();


                return true;
            }

            private async Task<bool> GenerateCreditManagerAfterRiskManager()
            {
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Code == "CreditManager");
                if (role == null)
                    throw new Exception();

                var statuses = await _dataContext.DicLoanHistoryStatuses.ToListAsync();

                var appStatus = statuses.FirstOrDefault(x => x.Code == "AfterRiskManager");
                if (appStatus == null)
                    throw new Exception();

                if (await _dataContext.RoleControls.AnyAsync(x => x.RoleId == role.Id && x.LoanHistoryStatusId == appStatus.Id))
                    return true;

                var taskStatuses = await _dataContext.DicTaskStatuses.ToListAsync();

                var roleControlId = Guid.NewGuid();
                await _dataContext.RoleControls.AddAsync(new Shared.Data.Context.RoleControls
                {
                    Id = roleControlId,
                    RoleId = role.Id,
                    LoanHistoryStatusId = appStatus.Id,
                    NameRu = "Кредит менеджер",
                    NameKk = "Кредит менеджер"
                });


                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "InWork").Id,
                    NameRu = "На доработку",
                    NameKk = "На доработку",
                    IsApply = true,
                    HasForm = false,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "В этом случае заявка отправляется на повторную экспертизу",
                    DialogTitleRu = "Вы уверены что хотите отправить заявку на доработку?"
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "InWork").Id,
                    NameRu = "Отказать",
                    NameKk = "Отказать",
                    IsApply = false,
                    HasForm = true,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "",
                    DialogTitleRu = "Вы уверены что хотите отклонить заявку?"
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "Completed").Id,
                    NameRu = "Готово",
                    NameKk = "Готово",
                    IsApply = true,
                    HasForm = false,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "Пожалуйста убедитесь что необходимая информация предоставлена",
                    DialogTitleRu = "Вы уверены что хотите отправить к риск менеджеру?"
                });

                await _dataContext.SaveChangesAsync();


                return true;
            }

            private async Task<bool> GenerateCreditManagerAfterCommittee()
            {
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Code == "CreditManager");
                if (role == null)
                    throw new Exception();

                var statuses = await _dataContext.DicLoanHistoryStatuses.ToListAsync();

                var appStatus = statuses.FirstOrDefault(x => x.Code == "AfterCommittee");
                if (appStatus == null)
                    throw new Exception();

                if (await _dataContext.RoleControls.AnyAsync(x => x.RoleId == role.Id && x.LoanHistoryStatusId == appStatus.Id))
                    return true;

                var taskStatuses = await _dataContext.DicTaskStatuses.ToListAsync();

                var roleControlId = Guid.NewGuid();
                await _dataContext.RoleControls.AddAsync(new Shared.Data.Context.RoleControls
                {
                    Id = roleControlId,
                    RoleId = role.Id,
                    LoanHistoryStatusId = appStatus.Id,
                    NameRu = "Кредит менеджер",
                    NameKk = "Кредит менеджер"
                });
                                             
                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "Completed").Id,
                    NameRu = "Готово",
                    NameKk = "Готово",
                    IsApply = true,
                    HasForm = false,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "Пожалуйста убедитесь что необходимая информация предоставлена",
                    DialogTitleRu = "Вы уверены что хотите отправить к кредитному администратору?"
                });

                await _dataContext.SaveChangesAsync();


                return true;
            }

            private async Task<bool> GenerateComplianceManager()
            {
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Value == RoleType.ComplianceManager);
                if (role == null)
                {
                    await _dataContext.Roles.AddAsync(new Role
                    {
                        Value = RoleType.ComplianceManager,
                        Code = nameof(RoleType.ComplianceManager),
                        NameRu = "Комплеанс менеджер"
                    });
                    await _dataContext.SaveChangesAsync();

                    throw new RestException(HttpStatusCode.NotFound, "Не найдена роль");
                }
                var statuses = await _dataContext.DicLoanHistoryStatuses.ToListAsync();

                var appStatus = statuses.FirstOrDefault(x => x.Code == nameof(RoleType.ComplianceManager));
                if (appStatus == null)
                {
                    await _dataContext.DicLoanHistoryStatuses.AddAsync(new Shared.Data.Context.Dictionary.DicLoanHistoryStatus
                    {
                        Code = nameof(RoleType.ComplianceManager),
                        NameRu = "Комплеанс менеджер"
                    });
                    await _dataContext.SaveChangesAsync();

                    throw new RestException(HttpStatusCode.NotFound, "Не найден статус");
                }

                if (await _dataContext.RoleControls.AnyAsync(x => x.RoleId == role.Id && x.LoanHistoryStatusId == appStatus.Id))
                    return true;

                var taskStatuses = await _dataContext.DicTaskStatuses.ToListAsync();

                var roleControlId = Guid.NewGuid();
                await _dataContext.RoleControls.AddAsync(new Shared.Data.Context.RoleControls
                {
                    Id = roleControlId,
                    RoleId = role.Id,
                    LoanHistoryStatusId = appStatus.Id,
                    NameRu = appStatus.NameRu,
                    NameKk = appStatus.NameKk
                });

                await _dataContext.RoleControlsFields.AddAsync(new RoleControlsField
                {
                    NameRu = "Соответствие проекта требованиям",
                    NameKk = "Соответствие проекта требованиям",
                    RoleControlId = roleControlId
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "Rejected").Id,
                    NameRu = "Отказать",
                    NameKk = "Отказать",
                    IsApply = false,
                    HasForm = true,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "",
                    DialogTitleRu = "Вы уверены что хотите отклонить заявку?"
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "InWork").Id,
                    NameRu = "На доработку",
                    NameKk = "На доработку",
                    IsApply = false,
                    HasForm = false,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "Пожалуйста укажите причину доработки в замечаниях",
                    DialogTitleRu = "Вы уверены что хотите отправить заявку на доработку?"
                });

                await _dataContext.RoleControlsButtons.AddAsync(new RoleControlsButton
                {
                    TaskStatusId = taskStatuses.First(x => x.Code == "Completed").Id,
                    NameRu = "Готово",
                    NameKk = "Дайын",
                    IsApply = true,
                    HasForm = true,
                    RoleControlId = roleControlId,
                    DialogMessageRu = "",
                    DialogTitleRu = "Вы уверены что заявка проходит по всем требованиям?"
                });

                await _dataContext.SaveChangesAsync();


                return true;
            }
        }
    }
}
