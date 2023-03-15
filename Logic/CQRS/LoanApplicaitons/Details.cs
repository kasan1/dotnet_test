using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Assets;
using Agro.Bpm.Logic.CQRS.ClientExtraDetails;
using Agro.Bpm.Logic.CQRS.FinAnalysis;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs;
using Agro.Bpm.Logic.CQRS.RoleControls;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class Details
    {
        public class Query : IRequest<Response<LoanApplicationDetailsDto>>
        {
            public Guid LoanApplicationTaskId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<LoanApplicationDetailsDto>>
        {
            private readonly IMediator _mediator;
            private readonly DataContext _dataContext;
            private readonly ILogger<QueryHandler> _logger;

            public QueryHandler(IMediator mediator, DataContext dataContext, ILogger<QueryHandler> logger)
            {
                _mediator = mediator;
                _dataContext = dataContext;
                _logger = logger;
            }

            public async Task<Response<LoanApplicationDetailsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new LoanApplicationDetailsDto();

                var loanApplicationTask = await _dataContext.LoanApplicationTasks
                    .Include(x => x.LoanApplication)
                        .ThenInclude(x => x.DicLoanType)
                    .Include(x => x.Role)
                    .Include(x => x.DicTaskStatus)
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId);
                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                result.Application.LoanApplicationId = loanApplicationTask.ApplicationId;
                result.Application.CreatedDate = loanApplicationTask.LoanApplication.CreatedDate;
                result.Application.UserRole = loanApplicationTask.Role.Code;
                result.Application.Status = loanApplicationTask.DicTaskStatus.Code;
                result.Application.LoanType = loanApplicationTask.LoanApplication.DicLoanType.Value;

                var clientDetails = await _mediator.Send(new GetClientDetails.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id });
                result.ClientDetails = clientDetails.Data;                

                if (loanApplicationTask.LoanApplication.DicLoanType.Value == LoanTypeEnum.ExpressLeasing)
                {
                    result.Assets.Land = (await _mediator.Send(new LandAssets.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                    result.Assets.Bio = (await _mediator.Send(new BioAssets.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                    result.Assets.Flora = (await _mediator.Send(new FloraAssets.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                    result.Assets.Tech = (await _mediator.Send(new TechAssets.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                }
                else if (loanApplicationTask.LoanApplication.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                {
                    result.ClientExtraDetails.Owners = (await _mediator.Send(new Owners.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                    result.ClientExtraDetails.Licenses = (await _mediator.Send(new Licenses.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                    result.ClientExtraDetails.VatCertificates = (await _mediator.Send(new VatCertificate.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id })).Data;
                }                

                var contracts = await _mediator.Send(new Contracts.Contracts.Query() { LoanApplicationId = loanApplicationTask.LoanApplication.Id });
                result.Contracts = contracts.Data;

                var documentFiles = await _mediator.Send(new ListByEntities.ListQuery()
                {
                    EntityIds = new List<Guid> { loanApplicationTask.LoanApplication.Id },
                    EntityTypes = new List<EntityType> { EntityType.LoanApplication, EntityType.Personality }
                });
                result.Documents = documentFiles.Data;

                try
                {
                    var finAnalysis = await _mediator.Send(new Result.Query() { LoanApplicationId = loanApplicationTask.ApplicationId });
                    result.FinAnalysis = finAnalysis.Data;
                }
                catch (Exception exception)
                {
                    _logger.LogError("Finance analysis query exception: ", exception);
                }

                try
                {
                    var controls = await _mediator.Send(new Controls.Query() { 
                        LoanApplicationTaskId = loanApplicationTask.Id,
                        UserId = loanApplicationTask.UserId.Value
                    });
                    result.Forms = controls.Data;
                }
                catch (Exception exception)
                {
                    _logger.LogError("Controls query exception: ", exception);
                }                

                return Response.Success("Запрос выполнен успешно", result);
            }

            private string GetMaritalStatusName(MaritalStatusEnum maritalStatusEnum)
            {
                switch (maritalStatusEnum)
                {
                    case MaritalStatusEnum.Single:
                        return "Не женат/не замужем";
                    case MaritalStatusEnum.Married:
                        return "Женат/замужем";
                    case MaritalStatusEnum.Divorced:
                        return "Разведен/Разведена";
                    case MaritalStatusEnum.Widower:
                        return "Вдовец/Вдова";
                    default:
                        return "";
                }
            }
                
        }
    }
}
