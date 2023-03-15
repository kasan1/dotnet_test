using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.Sender;
using Agro.Shared.Logic.Services.Sender.Operations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Agro.Shared.Logic.CQRS.Notifications;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class CreateTask
    {
        public class Command : IRequest<Response<Guid>>
        {
            public Guid LoanApplicationId { get; set; }

            public Guid CamundaTaskId { get; set; }

            public string RoleCode { get; set; }

            public string StatusCode { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Guid>>
        {
            private readonly DataContext _dataContext;
            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<AppRole> _roleManager;
            private readonly ILogger<Handler> _logger;
            private readonly ISenderService _emailSenderService;
            private readonly IMediator _mediator;
            private readonly string _adminIdentifier = "000000000000";

            public Handler(DataContext dataContext, 
                UserManager<AppUser> userManager,
                RoleManager<AppRole> roleManager,
                ILogger<Handler> logger,
                ISenderService emailSenderService,
                IMediator mediator)
            {
                _dataContext = dataContext;
                _userManager = userManager;
                _roleManager = roleManager;
                _logger = logger;
                _emailSenderService = emailSenderService;
                _mediator = mediator;
            }

            public async Task<Response<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                var taskid = request.CamundaTaskId;
                var loanApplication = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => x.Id == request.LoanApplicationId && !x.IsDeleted);
                if (loanApplication == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Loan application not found");

                var previousProcessStatus = await _dataContext.DicLoanHistoryStatuses.FirstOrDefaultAsync(x => x.Id == loanApplication.StatusId && !x.IsDeleted);
                if (previousProcessStatus == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Process status not found");

                var processStatus = await _dataContext.DicLoanHistoryStatuses
                    .Include(x => x.DicApplicationStatus)
                    .FirstOrDefaultAsync(x => x.Code == request.StatusCode && !x.IsDeleted);
                if (processStatus == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Process status not found");

                var role = await _roleManager.FindByNameAsync(request.RoleCode);
                if (role == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Role not found");

                var taskStatusCreated = await _dataContext.DicTaskStatuses.FirstOrDefaultAsync(x => x.Code == "Created" && !x.IsDeleted);
                if (taskStatusCreated == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Task status 'Created' not found");

                var inWorkTask = await _dataContext.LoanApplicationTasks.FirstOrDefaultAsync(x => 
                        !x.IsDeleted &&
                        x.ApplicationId == loanApplication.Id &&
                        x.RoleId == role.Id &&
                        x.StatusId == processStatus.Id &&
                        x.DicTaskStatus.Code == "InWork"
                    );

                // Закрывает задачу отправленную на доработку, чтобы зафиксировать факт исправления
                if (inWorkTask != null)
                {
                    var taskStatusComplete = await _dataContext.DicTaskStatuses
                        .FirstOrDefaultAsync(x => x.Code == "Completed" && !x.IsDeleted);
                    if (taskStatusComplete == null)
                        throw new RestException(HttpStatusCode.NotFound, "Task status 'Completed' not found");

                    inWorkTask.TaskStatusId = taskStatusComplete.Id;
                }

                //сотрудник занимался текущей заявкой на ранних стадиях
                var userId = await _dataContext.LoanApplicationTasks
                        .Where(x => !x.IsDeleted && x.ApplicationId == loanApplication.Id && x.RoleId == role.Id)
                        .Select(x => x.UserId)
                        .FirstOrDefaultAsync();

                if (userId == null)
                {
                    //сотрудники подходящей ролью 
                    var usersInRole = await _userManager
                        .GetUsersInRoleAsync(role.Name);
                    var userIdsInRole = usersInRole.Select(u => u.Id);

                    var userIds = await _userManager.Users
                        .Where(u =>
                                     userIdsInRole.Contains(u.Id) &&
                                     u.Branches.Any(b => b.BranchId == loanApplication.BranchId))
                        .Select(u => u.Id)
                        .ToListAsync(cancellationToken);

                    if (userIds.Any())
                    {

                        //статистика сотрудников
                        var userStats = await _dataContext.LoanApplicationTasks
                            .Where(lat => lat.TaskStatusId == taskStatusCreated.Id && !lat.IsDeleted
                                && userIds.Contains(lat.UserId.Value))
                            .GroupBy(lat => new { lat.UserId })
                            .Select(lat =>
                                new
                                {
                                    lat.Key.UserId,
                                    Count = lat.Count(),
                                    CreatedDate = lat.Min(xx => xx.CreatedDate)
                                })
                            .OrderBy(grouping => grouping.Count)
                            .ThenBy(grouping => grouping.CreatedDate)
                            .ToListAsync();

                        //выбор сотрудника без задач
                        userId = userIds.FirstOrDefault(userId => !userStats.Any(s => s.UserId == userId));

                        //выбор сотрудника с меньшей нагрузкой
                        if (userId == null || userId == Guid.Empty)
                            userId = userStats.FirstOrDefault()?.UserId;
                    }

                    //назначаем админ пользователю, чтобы он вручную переназначил задачу
                    if (userId == null || userId == Guid.Empty)
                    {
                        _logger.LogWarning("Responsible person with role '{0}' not found", role.Name);
                        
                        var admin = await _userManager.FindByNameAsync(_adminIdentifier);
                        if (admin == null)
                            throw new Exception($"Admin user not found. Task '{taskid}' wasn't assigned to user");

                        userId = admin.Id;

                        var taskNotAssignedEmailOperation = new TaskNotAssignedEmailOperation(taskid, role.Name);
                        var emailMessage = taskNotAssignedEmailOperation.GetMessage(new List<string> { admin.Email });

                        _emailSenderService.Send(emailMessage);

                        _logger.LogWarning("Task '{0}' was assigned to admin user", taskid);
                    }                        
                }

                await _dataContext.LoanApplicationTasks.AddAsync(new LoanApplicationTask
                {
                    Id = taskid,
                    ApplicationId = loanApplication.Id,
                    RoleId = role.Id,
                    UserId = userId,
                    StatusId = processStatus.Id,
                    TaskStatusId = taskStatusCreated.Id,
                    AppointmentDate = DateTime.Now
                });

                loanApplication.StatusId = processStatus.Id;

                await _dataContext.SaveChangesAsync(cancellationToken);

                if (processStatus.StatusId.HasValue && previousProcessStatus.StatusId != processStatus.StatusId)
                {
                    var createNotificationCommand = new Create.CreateNotificationCommand
                    {
                        LoanApplicationTaskId = taskid,
                        UserId = loanApplication.UserId
                    };
                    createNotificationCommand.SetValues(loanApplication.RegNumber, processStatus.DicApplicationStatus.NameRu, processStatus.DicApplicationStatus.NameKk);
                    await _mediator.Send(createNotificationCommand, cancellationToken);
                }

                return Response.Success("Запрос выполнен успешно", taskid);
            }
        }
    }
}
