using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using MediatR;
using Agro.Shared.Logic.Models.System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;
using Agro.Shared.Data.Primitives;
using System.Collections.Generic;
using Agro.Shared.Logic.Extensions;
using Agro.Okaps.Logic.Common.Enums;
using Agro.Shared.Logic.CQRS.ClientExtraDetails;

namespace Agro.Okaps.Logic.CQRS.ClientDetails
{
    public class GetAnketaFile
    {
        public class Command : IRequest<DownloadFileResult>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, DownloadFileResult>
        {
            private readonly IHostEnvironment _hostEnvironment;
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;

            public CommandHandler(
                DataContext dataContext,
                IMediator mediator,
                IHostEnvironment hostEnvironment)
            {
                _hostEnvironment = hostEnvironment;
                _dataContext = dataContext;
                _mediator = mediator;
            }

            public async Task<DownloadFileResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanType)
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Заявка не найдена");

                var details = await _dataContext.LoanApplicationDetails
                    .Include(x => x.DetailsPersonalities)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id);

                var templateFilename = "Anketa.docx";
                if (application.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                    templateFilename = "Anketa-Standard.docx";

                var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "docs", "templates", templateFilename);
                byte[] byteArray = File.ReadAllBytes(filePath);

                var mem = new MemoryStream();

                mem.Write(byteArray, 0, byteArray.Length);

                WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true);

                var body = wordDoc.MainDocumentPart.Document.Body;

                var organizationPersonalityDetails = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Organization);
                var organizationId = await FillGeneralInformationTable(organizationPersonalityDetails.PersonalityId, body);

                var headPersonality = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Head);
                await FillPersonTable(headPersonality?.PersonalityId, body, (int)AnketaTables.Head);

                var bookerPersonality = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Booker);
                await FillPersonTable(bookerPersonality?.PersonalityId, body, (int)AnketaTables.Booker);

                var contactsPersonalities = details.DetailsPersonalities
                    .Where(x => x.PersonalityType == PersonalityTypeEnum.Contact)
                    .Select(x => x.PersonalityId);
                await FillContacts(contactsPersonalities, body);
                                
                await FillAffiliatedCompanies(organizationId, body);
                await FillCreditHistory(organizationPersonalityDetails.PersonalityId, body);

                if (application.DicLoanType.Value == LoanTypeEnum.ExpressLeasing)
                {
                    await FillAssets(application.Id, body);
                }
                else if (application.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                {
                    await FillClientExtraDetails(application.Id, body);
                }

                wordDoc.Close();

                mem.Seek(0, SeekOrigin.Begin);

                return new DownloadFileResult
                {
                    ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    Filename = "Анкета.docx",
                    Stream = mem
                };
            }

            private async Task<Guid> FillGeneralInformationTable(Guid personalityId, Body body)
            {
                var organization = await _dataContext.Organizations
                    .Where(x => x.PersonalityId == personalityId)
                    .Select(x => new {
                        x.Id,
                        x.Personality.FullName,
                        Address = new
                        {
                            x.Personality.Address.Register,
                            x.Personality.Address.Fact
                        },
                        Phone = new
                        {
                            x.Personality.Phone.Home,
                            x.Personality.Phone.Mobile,
                            x.Personality.Phone.Work
                        },
                        x.Personality.Fax,
                        x.Personality.Email,
                        OwnerShipForm = x.DicOwnershipForm.NameRu,
                        Oked = x.OKED.Select(xx => xx.DicOKED.NameRu),
                        x.Personality.Identifier,
                        OrganisationTypeCode = x.DicOrganizationType.Code,
                        LegalFormCode = x.DicOrganizationAndLegalForm.Value,
                        IdentificationDocument = x.Personality.Documents.Where(xx => xx.Document.DocumentType.DocumentType == DocumentTypeEnum.Identification).Select(xx => new
                        {
                            xx.Document.Number,
                            xx.Document.Issuer,
                            xx.Document.DateIssue
                        }),
                        x.Parent,
                        BankAccounts = x.Personality.BankAccounts.Select(xx => new
                        {
                            xx.BIC,
                            xx.Number
                        })
                    })
                    .FirstOrDefaultAsync();

                if (organization == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Детальная информация не найдена");

                var organizationTable = body.Elements<Table>().ElementAt((int)AnketaTables.GeneralInformation);
                foreach (var text in organizationTable.Descendants<Text>())
                {
                    text.CheckAndReplaceText("fullname", organization.FullName);
                    text.CheckAndReplaceText("registerAddress", organization.Address.Register);
                    text.CheckAndReplaceText("factAddress", organization.Address.Fact);

                    var contactInfo = GetContactInfo(organization.Phone.Work, organization.Phone.Mobile, organization.Phone.Home, organization.Fax, organization.Email);
                    text.CheckAndReplaceText("contactInfo", contactInfo);
                    text.CheckAndReplaceText("ownershipType", organization.OwnerShipForm);
                    text.CheckAndReplaceText("oked", string.Join(", ", organization.Oked));

                    if (organization.LegalFormCode == OrganizationAndLegalFormEnum.Juridical)
                    {
                        text.CheckAndReplaceText("bin", organization.Identifier);
                        text.CheckAndReplaceText("iin", null);
                    }
                    else
                    {
                        text.CheckAndReplaceText("bin", null);
                        text.CheckAndReplaceText("iin", organization.Identifier);
                    }

                    var identificationDocumentInfo = organization.IdentificationDocument.Select(x => $"Номер: {x.Number}, кем выдано: {x.Issuer}, дата выдачи: {x.DateIssue}");
                    text.CheckAndReplaceText("identificationDocument", string.Join("; ", identificationDocumentInfo));
                    text.CheckAndReplaceText("parent", organization.Parent);

                    var bankAccountInfo = organization.BankAccounts.Select(x => $"БИК: {x.BIC}, Счет: {x.Number}");
                    text.CheckAndReplaceText("bankAccounts", string.Join("; ", bankAccountInfo));

                    text.CheckAndReplaceText("affiliatredOrganizations", null);
                }


                return organization.Id;
            }

            private async Task FillPersonTable(Guid? personalityId, Body body, int tableIndex)
            {
                var person = await _dataContext.People
                    .Where(x => x.PersonalityId == personalityId)
                    .Select(x => new {
                        x.Id,
                        x.Personality.FullName,
                        Address = new
                        {
                            x.Personality.Address.Register,
                            x.Personality.Address.Fact
                        },
                        Phone = new
                        {
                            x.Personality.Phone.Home,
                            x.Personality.Phone.Mobile,
                            x.Personality.Phone.Work
                        },
                        x.BirthDate,
                        x.BirthPlace,
                        x.Personality.Identifier,
                        IdentificationDocument = x.Personality.Documents.Where(xx => xx.Document.DocumentType.DocumentType == DocumentTypeEnum.Identification).Select(xx => new
                        {
                            xx.Document.Number,
                            xx.Document.Issuer,
                            xx.Document.DateIssue
                        }),
                        x.Education,
                        WorkExperience = new {
                            x.Personality.WorkExperience.Total,
                            x.Personality.WorkExperience.Agriculture,
                        },
                        MariageStatus = x.DicMariageStatus.NameRu,
                        x.Spouse
                    })
                    .FirstOrDefaultAsync();

                if (personalityId.HasValue && person == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Руководитель не найден");

                var table = body.Elements<Table>().ElementAt(tableIndex);
                foreach (var text in table.Descendants<Text>())
                {
                    text.CheckAndReplaceText("fullname", person?.FullName);
                    text.CheckAndReplaceText("workNumber", person?.Phone?.Work);
                    text.CheckAndReplaceText("mobileNumber", person?.Phone?.Mobile);
                    text.CheckAndReplaceText("homeNumber", person?.Phone?.Home);
                    text.CheckAndReplaceText("birthInfo", person != null ? $"{person.BirthDate:dd.MM.yyyy} {person.BirthPlace}" : "");
                    text.CheckAndReplaceText("factAddress", person?.Address?.Fact);
                    text.CheckAndReplaceText("registerAddress", person?.Address?.Register);
                    text.CheckAndReplaceText("education", person?.Education);
                    text.CheckAndReplaceText("totalWorkExperience", person?.WorkExperience?.Total);
                    text.CheckAndReplaceText("agricultureWorkExperience", person?.WorkExperience?.Agriculture);
                    text.CheckAndReplaceText("marriageStatus", person?.MariageStatus);
                    text.CheckAndReplaceText("spouse", person?.Spouse);

                    var identificationDocumentInfo = person?.IdentificationDocument.Select(x => $"Номер: {x.Number}, кем выдано: {x.Issuer}, дата выдачи: {x.DateIssue}");
                    text.CheckAndReplaceText("identificationDocument", string.Join("; ", identificationDocumentInfo ?? new string[0]));
                }
            }

            private async Task FillContacts(IEnumerable<Guid> personalityIds, Body body)
            {
                var people = await _dataContext.People
                    .Where(x => personalityIds.Contains(x.PersonalityId))
                    .Select(x => new {
                        x.Id,
                        x.Personality.FullName,
                        Address = new
                        {
                            x.Personality.Address.Register,
                            x.Personality.Address.Fact
                        },
                        Phone = new
                        {
                            x.Personality.Phone.Home,
                            x.Personality.Phone.Mobile,
                            x.Personality.Phone.Work
                        }
                    })
                    .ToListAsync();

                var contacts = body.Descendants<Text>().FirstOrDefault(tbl => tbl.InnerText.Contains("contacts"));

                var data = people.Select(person => $"{person.FullName}, {person.Phone.Mobile}, {person.Address.Register}");
                contacts.CheckAndReplaceText("contacts", string.Join("; ", data));
            }

            private async Task FillAffiliatedCompanies(Guid organizationId, Body body)
            {
                var affiliatedOrganizations = await _dataContext.Organizations
                    .Where(x => x.AffiliatedOrganizatonId == organizationId)
                    .Select(x => new {
                        x.Id,
                        x.Personality.FullName,
                        Address = new
                        {
                            x.Personality.Address.Register,
                            x.Personality.Address.Fact
                        },
                        x.ShareInCapital,
                        BankAccounts = x.Personality.BankAccounts.Select(xx => new
                        {
                            xx.BIC,
                            xx.Number
                        }),
                        Debts = x.Personality.Depts.Select(xx => new
                        {
                            xx.BIC,
                            xx.Value
                        })
                    })
                    .ToListAsync();


                var affiliatedOrganizationsTable = body.Elements<Table>().ElementAt((int)AnketaTables.AffiliatedOrganisations);

                affiliatedOrganizations.ForEach(x =>
                {
                    var bankAccounts = string.Join("; ", x.BankAccounts.Select(xx => $"БИК: {xx.BIC}, Счет: {xx.Number}"));
                    var debts = string.Join("; ", x.Debts.Select(xx => $"БИК: {xx.BIC}, Сумма: {xx.Value}"));

                    affiliatedOrganizationsTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.FullName}, {x.Address.Register}"),
                                 GenerateCellWithContent(bankAccounts),
                                 GenerateCellWithContent($"{x.ShareInCapital}"),
                                 GenerateCellWithContent(debts)));
                });
            }

            private async Task FillCreditHistory(Guid personalityId, Body body)
            {
                var creditHistory = await _dataContext.CreditHistory
                    .Where(x => x.PersonalityId == personalityId)
                    .Select(x => new {
                        x.Id,
                        x.FullName,
                        x.Sum,
                        x.DateIssue,
                        x.Period,
                        x.Balance
                    })
                    .ToListAsync();

                var creditHistoryTable = body.Elements<Table>().ElementAt((int)AnketaTables.CreditHistory);

                creditHistory.ForEach(x =>
                {
                    creditHistoryTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.FullName}"),
                                 GenerateCellWithContent($"{x.Sum}"),
                                 GenerateCellWithContent($"{x.DateIssue:dd.MM.yyyy}"),
                                 GenerateCellWithContent($"{x.Period}"),
                                 GenerateCellWithContent($"{x.Balance}"),
                                 GenerateCellWithContent($"")
                            )
                    );
                });
            }

            private async Task FillAssets(Guid applicationId, Body body)
            {
                var assets = await _mediator.Send(new Shared.Logic.CQRS.ClientActivities.Get.GetActivitiesQuery { LoanApplicationId = applicationId });

                var landAssetsTable = body.Elements<Table>().ElementAt((int)AnketaExpressTables.LandAssets);
                assets.Data.LandActivities.ToList().ForEach(x =>
                {
                    landAssetsTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.LandType}"),
                                 GenerateCellWithContent($"{x.Square}"),
                                 GenerateCellWithContent($"{x.OwnershipType}")
                            )
                    );
                });
                //var totalSquareText = landAssetsTable.Descendants<Text>().FirstOrDefault(tbl => tbl.InnerText.Contains("square"));
                //CheckAndReplaceText(totalSquareText, "square", $"{assets.Data.LandActivities.Sum(x => x.Square)}");

                var floraAssetsHistoryTable = body.Elements<Table>().ElementAt((int)AnketaExpressTables.FloraAssetsHistory);
                assets.Data.FloraActivities.ToList().ForEach(x =>
                {
                    floraAssetsHistoryTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.Culture}"),
                                 GenerateCellWithContent($"{x.ProductivityCurrentYear}"),
                                 GenerateCellWithContent($"{x.ProductivityLastYear}"),
                                 GenerateCellWithContent($"{x.ProductivityBeforeLastYear}")
                            )
                    );
                });

                var floraAssetsTable = body.Elements<Table>().ElementAt((int)AnketaExpressTables.FloraAssets);
                assets.Data.FloraActivities.Select((x, i) => new { index = i, asset = x }).ToList().ForEach(x =>
                 {
                     floraAssetsTable.Append(new TableRow(
                                  GenerateCellWithContent($"{x.index + 1}"),
                                  GenerateCellWithContent($"{x.asset.Culture}"),
                                  GenerateCellWithContent($"{x.asset.PlannedSquare}"),
                                  GenerateCellWithContent($"{x.asset.SeedingRate}"),
                                  GenerateCellWithContent($"{x.asset.PriceRealization}"),
                                  GenerateCellWithContent($"{x.asset.Cost}")
                             )
                     );
                 });

                var techAssetsTable = body.Elements<Table>().ElementAt((int)AnketaExpressTables.TechAssets);
                assets.Data.TechnicActivities.Select((x, i) => new { index = i, asset = x }).ToList().ForEach(x =>
                {
                    techAssetsTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.index + 1}"),
                                 GenerateCellWithContent($"{x.asset.Fullname}"),
                                 GenerateCellWithContent($"{x.asset.DateIssue:dd.MM.yyyy}"),
                                 GenerateCellWithContent($"{x.asset.Count}"),
                                 GenerateCellWithContent($"{x.asset.CountOfCorrect}"),
                                 GenerateCellWithContent(x.asset.IsPledged ? "Да" : "Нет"),
                                 GenerateCellWithContent($"{x.asset.PledgeDescription}")
                            )
                    );
                });
                //var totalCountText = techAssetsTable.Descendants<Text>().FirstOrDefault(tbl => tbl.InnerText.Contains("count"));
                //CheckAndReplaceText(totalCountText, "count", $"{assets.Data.TechnicActivities.Sum(x => x.Count)}");
                //var totalCountOfCorrectText = techAssetsTable.Descendants<Text>().FirstOrDefault(tbl => tbl.InnerText.Contains("countOfCorrect"));
                //CheckAndReplaceText(totalCountOfCorrectText, "countOfCorrect", $"{assets.Data.TechnicActivities.Sum(x => x.CountOfCorrect)}");

                var liveAssetsTable = body.Elements<Table>().ElementAt((int)AnketaExpressTables.LiveAssets);
                assets.Data.LivestockActivities.Select((x, i) => new { index = i, asset = x }).ToList().ForEach(x =>
                {
                    liveAssetsTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.index}"),
                                 GenerateCellWithContent($"{x.asset.LivestockType}"),
                                 GenerateCellWithContent($"{x.asset.Count}"),
                                 GenerateCellWithContent($"{x.asset.LiveWeight}"),
                                 GenerateCellWithContent($"{x.asset.SlaughterWeight}"),
                                 GenerateCellWithContent($"{x.asset.LivePrice}"),
                                 GenerateCellWithContent($"{x.asset.SlaughterPrice}")
                            )
                    );
                });
            }

            private async Task FillClientExtraDetails(Guid applicationId, Body body)
            {
                var detailsResponse = await _mediator.Send(new Details.Query() { LoanApplicationId = applicationId });
                var runProperties = new RunProperties() { FontSize = new FontSize() { Val = "20" } };

                var ulOwnersTable = body.Elements<Table>().ElementAt((int)AnketaStandardTables.OwnersUL);
                detailsResponse.Data.UlOwners.ToList().ForEach(x =>
                {
                    var requisites = string.Join("; ", x.BankAccounts.Select(ba => $"БИК: {ba.BIC}, Счет: {ba.Number}"));
                    ulOwnersTable.Append(new TableRow(
                                 GenerateCellWithContent($"{x.FullName}"),
                                 GenerateCellWithContent($"{x.Rate}"),
                                 GenerateCellWithContent(requisites)
                            )
                    );
                });

                var flOwnersTable = body.Elements<Table>().ElementAt((int)AnketaStandardTables.OwnersFL);
                detailsResponse.Data.FlOwners.Select((x, index) => (x, index)).ToList().ForEach(cartage =>
                {
                    var identityDoc = $"Номер: {cartage.x.IdentificationDocument.Number}, кем выдано: {cartage.x.IdentificationDocument.Issuer}, дата выдачи: {cartage.x.IdentificationDocument.DateIssue:dd-MM-yyyy}";
                    flOwnersTable.Append(new TableRow(
                                 GenerateCellWithContent($"{cartage.index + 1}"),
                                 GenerateCellWithContent($"{cartage.x.FullName}"),
                                 GenerateCellWithContent(identityDoc),
                                 GenerateCellWithContent(cartage.x.Address.Fact)
                            )
                    );
                });

                var licencesTable = body.Elements<Table>().ElementAt((int)AnketaStandardTables.Licences);
                detailsResponse.Data.Licenses.ToList().ForEach(x =>
                {
                    var licenceDoc = $"{x.Document.Number}, {x.Document.DateIssue:dd-MM-yyyy}";
                    licencesTable.Append(new TableRow(
                                 GenerateCellWithContent(licenceDoc),
                                 GenerateCellWithContent(x.Document.Issuer),
                                 GenerateCellWithContent(x.Essence)
                            )
                    );
                });

                if (detailsResponse.Data.VatCertificate != null)
                {
                    var certificateTable = body.Elements<Table>().ElementAt((int)AnketaStandardTables.Certificate);
                    var certificateText = $"{detailsResponse.Data.VatCertificate.Number}, {detailsResponse.Data.VatCertificate.DateIssue:dd-MM-yyyy}";
                    certificateTable.Append(new TableRow(
                                 GenerateCellWithContent(certificateText)
                            )
                    );
                }
            }

            private TableCell GenerateCellWithContent(string content) {
                var runProperties = new RunProperties() { FontSize = new FontSize() { Val = "20" } };
                return new TableCell(new Paragraph(new Run(runProperties, new Text(content))));
            }

            private string GetContactInfo(string workNumber, string mobileNumber, string homeNumber, string fax, string email)
            {
                var phoneNumbers = new List<string>();
                if (!string.IsNullOrEmpty(workNumber))
                {
                    phoneNumbers.Add($"рабочий: {workNumber}");
                }
                if (!string.IsNullOrEmpty(mobileNumber))
                {
                    phoneNumbers.Add($"мобильный: {mobileNumber}");
                }
                if (!string.IsNullOrEmpty(homeNumber))
                {
                    phoneNumbers.Add($"домашний: {homeNumber}");
                }

                var contactInfo = string.Join(", ", phoneNumbers);

                if (!string.IsNullOrEmpty(fax))
                {
                    contactInfo += $"/{fax}";
                }
                if (!string.IsNullOrEmpty(email))
                {
                    contactInfo += $"/{email}";
                }

                return contactInfo;
            }
        }
    }
}
