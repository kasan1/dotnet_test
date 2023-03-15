using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;
using System;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Data.Entities.ClientExtraDetails;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Services.ClientDetails;
using Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs;
using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientExtraDetails
{
    public class CreateOrUpdate
    {
        public class Command : ExtraDetailsDto, IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IClientDetailsService _clientDetailsService;

            public Handler(DataContext dataContext,
                IClientDetailsService clientDetailsService)
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

                await _clientDetailsService.Init(cancellation: cancellationToken);

                ExtraDetails extraDetails = null;
                List<UlOwner> ulOwners = null;
                List<FlOwner> flOwners = null;
                List<License> licenses = null;

                if (request.Id.HasValue)
                {
                    extraDetails = await _dataContext.LoanApplicationExtraDetails.FirstOrDefaultAsync(x => x.Id == request.Id);

                    ulOwners = await _dataContext.UlOwners.Where(x => x.ExtraDetailsId == request.Id).ToListAsync();
                    flOwners = await _dataContext.FlOwners.Where(x => x.ExtraDetailsId == request.Id).ToListAsync();
                    licenses = await _dataContext.Licenses.Where(x => x.ExtraDetailsId == request.Id).ToListAsync();
                }

                if (extraDetails != null)
                {
                    var deleteUlOwners = ulOwners.Where(x => !request.UlOwners?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteUlOwners.Any())
                        _dataContext.UlOwners.RemoveRange(deleteUlOwners);

                    var deleteFlOwners = flOwners.Where(x => !request.FlOwners?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteFlOwners.Any())
                        _dataContext.FlOwners.RemoveRange(deleteFlOwners);

                    var deleteLicenses = licenses.Where(x => !request.Licenses?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteLicenses.Any())
                        _dataContext.Licenses.RemoveRange(deleteLicenses);
                }
                else
                {
                    extraDetails = new ExtraDetails
                    {
                        Id = Guid.NewGuid(),
                        LoanApplicationId = application.Id
                    };
                    await _dataContext.LoanApplicationExtraDetails.AddAsync(extraDetails);
                }

                if (request.UlOwners != null)
                    foreach (var ulOwnerDto in request.UlOwners)
                        await CreateUlOwner(extraDetails.Id, ulOwners, ulOwnerDto);

                if (request.FlOwners != null)
                    foreach (var flOwnerDto in request.FlOwners)
                        await CreateFlOwner(extraDetails.Id, flOwners, flOwnerDto);

                if (request.Licenses != null)
                    foreach (var licenseDto in request.Licenses)
                        await CreateLicense(extraDetails.Id, licenses, licenseDto);                    

                if (request.VatCertificate != null)
                    extraDetails.VatCertificateId = await _clientDetailsService.CreateOrUpdateDocumentAsync(request.VatCertificate, DocumentTypeEnum.VatCertificate);

                await _dataContext.SaveChangesAsync();

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }

            #region ulOwner
            public async Task<Guid> CreateUlOwner(Guid extraDetailsId, List<UlOwner> ulOwners, UlOwnerDto ulOwnerDto)
            {
                UlOwner ulOwner = null;
                if (ulOwnerDto.Id.HasValue)
                {
                    ulOwner = ulOwners?.FirstOrDefault(x => x.Id == ulOwnerDto.Id);
                    ulOwner.Rate = ulOwnerDto.Rate;
                }

                if (ulOwner == null)
                {
                    ulOwner = new UlOwner
                    {
                        Id = Guid.NewGuid(),
                        ExtraDetailsId = extraDetailsId,
                        Rate = ulOwnerDto.Rate
                    };
                    await _dataContext.UlOwners.AddAsync(ulOwner);
                }

                var organization = await _clientDetailsService.CreateOrUpdateOrganizationAsync(new OwnerOrganizationDto
                {
                    Id = ulOwner.OrganizationId,
                    FullName = ulOwnerDto.FullName,
                    BankAccounts = ulOwnerDto.BankAccounts
                }, default);

                ulOwner.OrganizationId = organization.Id;
                return ulOwner.Id;
            }

            #endregion

            #region flOwner
            public async Task<Guid> CreateFlOwner(Guid extraDetailsId, List<FlOwner> flOwners, FlOwnerDto flOwnerDto)
            {
                FlOwner flOwner = null;
                if (flOwnerDto.Id.HasValue)
                {
                    flOwner = flOwners?.FirstOrDefault(x => x.Id == flOwnerDto.Id);
                }

                if (flOwner == null)
                {
                    flOwner = new FlOwner
                    {
                        Id = Guid.NewGuid(),
                        ExtraDetailsId = extraDetailsId
                    };
                    await _dataContext.FlOwners.AddAsync(flOwner);
                }

                var person = await _clientDetailsService.CreateOrUpdatePersonAsync(new PersonDto
                {
                    Id = flOwner.PersonId,
                    FullName = flOwnerDto.FullName,
                    Address = flOwnerDto.Address,
                    IdentificationDocument = flOwnerDto.IdentificationDocument
                });

                flOwner.PersonId = person.Id;
                return flOwner.Id;
            }

            #endregion

            #region license
            public async Task<Guid> CreateLicense(Guid extraDetailsId, List<License> licenses, LicenseDto  licenseDto)
            {
                License license = null;
                if (licenseDto.Id.HasValue)
                {
                    license = licenses?.FirstOrDefault(x => x.Id == licenseDto.Id);
                }

                if (license == null)
                {
                    license = new License
                    {
                        Id = Guid.NewGuid(),
                        ExtraDetailsId = extraDetailsId
                    };
                    await _dataContext.Licenses.AddAsync(license);
                }

                license.DocumentId = await _clientDetailsService.CreateOrUpdateDocumentAsync(licenseDto.Document, DocumentTypeEnum.License);
                license.Essence = licenseDto.Essence;
                return license.Id;
            }

            #endregion
        }
    }
}
