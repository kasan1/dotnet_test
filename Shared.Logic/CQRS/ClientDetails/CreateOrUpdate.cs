using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.LoanApplications;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using System.Net;
using Agro.Shared.Logic.Services.ClientDetails;
using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientDetails
{
    public class CreateOrUpdate
    {
        public class Command : DetailsDto, IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Organization)
                    .NotNull()
                    .WithMessage("Пожалуйста заполните данные об организации");
                RuleFor(x => x.Head)
                    .NotNull()
                    .WithMessage("Пожалуйста заполните данные о руководителе");
            }
        }

        public class ListQueryHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IClientDetailsService _clientDetailsService;

            public ListQueryHandler(DataContext dataContext, IClientDetailsService clientDetailsService)
            {
                _dataContext = dataContext;
                _clientDetailsService = clientDetailsService;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.Status != ApplicationTypeEnum.Temp)
                    throw new RestException(HttpStatusCode.BadRequest, "Заявка уже в работе, вы не можете вносить изменения");
                               
                var regionIds = new List<Guid?> {
                    request.Organization.RegionId,
                    request.Head.RegionId, request.Booker?.RegionId, request.Beneficiary?.RegionId };

                await _clientDetailsService.Init(request.Organization.OKED, regionIds, cancellationToken);


                Data.Context.LoanApplications.Details details = null;
                if (request.Id.HasValue)
                {
                    details = await _dataContext.LoanApplicationDetails.Include(x => x.DetailsPersonalities).FirstOrDefaultAsync(x => x.Id == request.Id.Value);
                    if (details == null)
                        throw new RestException(HttpStatusCode.NotFound, "Детали заявки не найдены");
                }
                else
                {
                    details = new Data.Context.LoanApplications.Details
                    {
                        Id = Guid.NewGuid(),
                        LoanApplicationId = application.Id,
                        HasBeneficiary = request.Beneficiary != null
                    };

                    await _dataContext.LoanApplicationDetails.AddAsync(details);
                }

                var opganization = await _clientDetailsService.CreateOrUpdateOrganizationAsync(request.Organization);
                
                //определяем филиал по региону организации
                var branch = await _dataContext.Branches.FirstOrDefaultAsync(x => x.RegionId == request.Organization.RegionId, cancellationToken);
                if (branch == null)
                    throw new RestException(HttpStatusCode.BadRequest, "По выбранному региону не найден филиал");
                
                application.BranchId = branch.Id;
                
                if (!request.Organization.Id.HasValue)
                {
                    await _dataContext.LoanApplicationDetailsPersonalities.AddAsync(new DetailsPersonality
                    {
                        PersonalityId = opganization.PersonalityId,
                        DetailsId = details.Id,
                        PersonalityType = PersonalityTypeEnum.Organization
                    });
                }

                var head = await _clientDetailsService.CreateOrUpdatePersonAsync(request.Head);
                if (!request.Head.Id.HasValue)
                {
                    await _dataContext.LoanApplicationDetailsPersonalities.AddAsync(new DetailsPersonality
                    {
                        PersonalityId = head.PersonalityId,
                        DetailsId = details.Id,
                        PersonalityType = PersonalityTypeEnum.Head
                    });
                }

                if (request.Booker != null)
                {
                    var booker = await _clientDetailsService.CreateOrUpdatePersonAsync(request.Booker);
                    if (!request.Booker.Id.HasValue)
                    {
                        await _dataContext.LoanApplicationDetailsPersonalities.AddAsync(new DetailsPersonality
                        {
                            PersonalityId = booker.PersonalityId,
                            DetailsId = details.Id,
                            PersonalityType = PersonalityTypeEnum.Booker
                        });
                    }
                }

                if (request.Beneficiary != null)
                {
                    var beneficiary = await _clientDetailsService.CreateOrUpdatePersonAsync(request.Beneficiary);
                    if (!request.Beneficiary.Id.HasValue)
                    {
                        await _dataContext.LoanApplicationDetailsPersonalities.AddAsync(new DetailsPersonality
                        {
                            PersonalityId = beneficiary.PersonalityId,
                            DetailsId = details.Id,
                            PersonalityType = PersonalityTypeEnum.Beneficiary
                        });
                    }
                }

                if (request.Representative != null)
                {
                    var representative = await _clientDetailsService.CreateOrUpdatePersonAsync(request.Representative);
                    if (!request.Representative.Id.HasValue)
                    {
                        await _dataContext.LoanApplicationDetailsPersonalities.AddAsync(new DetailsPersonality
                        {
                            PersonalityId = representative.PersonalityId,
                            DetailsId = details.Id,
                            PersonalityType = PersonalityTypeEnum.Representative
                        });
                    }
                }

                if (request.Contacts != null)
                {
                    var personalityIds = details.DetailsPersonalities?
                        .Where(x => x.PersonalityType == PersonalityTypeEnum.Contact)
                        .Select(x => x.PersonalityId);

                    var contactsToRemove = _dataContext.People
                        .Where(x => personalityIds.Contains(x.PersonalityId))
                        .Select(x => x.Id).ToHashSet() ?? new HashSet<Guid>();
                    foreach (var contactDto in request.Contacts)
                    {
                        if (contactDto.Id.HasValue)
                            contactsToRemove.Remove(contactDto.Id.Value);

                        var contact = await _clientDetailsService.CreateOrUpdatePersonAsync(contactDto);
                        if (!contactDto.Id.HasValue)
                        {
                            await _dataContext.LoanApplicationDetailsPersonalities.AddAsync(new DetailsPersonality
                            {
                                PersonalityId = contact.PersonalityId,
                                DetailsId = details.Id,
                                PersonalityType = PersonalityTypeEnum.Contact
                            });
                        }
                    }
                    _dataContext.People.Where(x => contactsToRemove.Contains(x.Id)).Delete();
                }

                await _dataContext.SaveChangesAsync();                

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
