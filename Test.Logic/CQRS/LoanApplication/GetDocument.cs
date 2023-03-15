using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Agro.Shared.Logic.Models.System;
using System.IO;
using Microsoft.Extensions.Hosting;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Agro.Shared.Logic.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agro.Shared.Data.Primitives;
using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class GetDocument
    {
        public class GetDocumentCommand : IRequest<DownloadFileResult>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<GetDocumentCommand, DownloadFileResult>
        {
            private readonly IHostEnvironment _hostEnvironment;
            private readonly DataContext _dataContext;
            private readonly string _headOfCompany;
            private readonly IMediator _mediator;

            public CommandHandler(
                DataContext dataContext,
                IMediator mediator,
                IHostEnvironment hostEnvironment)
            {
                _mediator = mediator;
                _hostEnvironment = hostEnvironment;
                _dataContext = dataContext;
                _headOfCompany = "Избастин К.Т."; // Избастин Каныш Темиртаевич
            }

            public async Task<DownloadFileResult> Handle(GetDocumentCommand request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanType)                    
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Заявка не найдена");

                var requisitesTableIndex = 2;
                var templateFilename = "Zayavlenie.docx";
                if (application.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                {
                    templateFilename = "Zayavlenie-Standard.docx";
                    requisitesTableIndex = 3;
                }

                var details = await _dataContext.LoanApplicationDetails
                    .Include(x => x.DetailsPersonalities)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id);

                var organizationPersonality = details.DetailsPersonalities.FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Organization);
                var organization = await _dataContext.Organizations
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.BankAccounts)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Address)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Phone)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.DicRegion)
                    .FirstOrDefaultAsync(x => x.PersonalityId == organizationPersonality.PersonalityId);

                var headPersonality = details.DetailsPersonalities.FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Head);
                var head = await _dataContext.People
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.BankAccounts)
                    .FirstOrDefaultAsync(x => x.PersonalityId == headPersonality.PersonalityId);


                var contracts = await _mediator.Send(new Contracts.ContractsQuery { ApplicationId = request.LoanApplicationId });

                var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "docs", "templates", templateFilename);
                byte[] byteArray = File.ReadAllBytes(filePath);

                var mem = new MemoryStream();

                mem.Write(byteArray, 0, byteArray.Length);

                WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true);

                var body = wordDoc.MainDocumentPart.Document.Body;
                var paragraphs = body.Elements<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            if (text.Text.Trim().Contains("Chairman"))
                            {
                                text.Text = text.Text.Trim().Replace("Chairman", _headOfCompany);
                            }

                            if (text.Text.Trim().Contains("OrganizationName"))
                            {
                                text.Text = text.Text.Trim().Replace("OrganizationName", organization.Personality.FullName);
                            }

                            if (text.Text.Trim().Contains("Goal"))
                            {
                                text.Text = text.Text.Trim().Replace("Goal", "");
                            }

                            if (text.Text.Trim().Contains("Area"))
                            {
                                text.Text = text.Text.Trim().Replace("Area",
                                    organization.Personality.DicRegion.NameRu);
                            }

                            if (text.Text.Trim().Contains("OrganizationName"))
                            {
                                text.Text = text.Text.Trim().Replace("OrganizationName",
                                    organization.Personality.FullName);
                            }

                            if (text.Text.Trim().Contains("Head"))
                            {
                                text.Text = text.Text.Trim().Replace("Head",
                                    head.Personality.ShortFullname());
                            }
                        }
                    }
                }

                var technicTable = body.Elements<Table>().ElementAt(0);
                var calcTable = body.Elements<Table>().ElementAt(1);
                var provisionsTable = body.Elements<Table>().ElementAt(2);

                calcTable.RemoveAllChildren<TableRow>();
                foreach (var contract in contracts.Data)
                {
                    RunProperties runProperties = new RunProperties();
                    FontSize fontSize = new FontSize() { Val = "20" };
                    runProperties.Append(fontSize);

                    calcTable?.Append(CreateCalcCoFinancingRow(contract.CalculatorResult.CoFinancing, runProperties));
                    calcTable?.Append(CreateCalcPeriodRow(contract.CalculatorResult.Rate, contract.CalculatorResult.Period, runProperties));
                    technicTable?.Append(CreateTechnicRow(contract.Technic, runProperties));
                    foreach (var accessor in contract.Accessories)
                    {
                        technicTable?.Append(CreateTechnicRow(accessor, runProperties));
                    }

                    if (application.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                    {
                        foreach (var provision in contract.Provisions)
                        {
                            provisionsTable?.Append(CreateProvisionRow(provision, runProperties));
                        }
                    }
                }
                
                foreach (TableRow row in body.Elements<Table>().ElementAt(requisitesTableIndex).Elements<TableRow>())
                {
                    foreach (TableCell cell in row.Descendants<TableCell>())
                    {
                        var paragraph = cell.Elements<Paragraph>();
                        foreach (var para in paragraph)
                        {
                            foreach (var run in para.Elements<Run>())
                            {
                                foreach (var text in run.Elements<Text>())
                                {

                                    if (text.Text.Trim().Contains("Address"))
                                    {
                                        text.Text = text.Text.Trim().Replace("Address",
                                            organization.Personality.Address.Register + (organization.Personality.Address.Fact != null 
                                                ? $", {organization.Personality.Address.Fact}" 
                                                : ""));
                                    }

                                    if (text.Text.Trim().Contains("Phone"))
                                    {
                                        text.Text = text.Text.Trim().Replace("Phone",
                                            organization.Personality.Phone.Work);
                                    }

                                    if (text.Text.Trim().Contains("Faks"))
                                    {
                                        text.Text = text.Text.Trim().Replace("Faks",
                                            organization.Personality.Fax);
                                    }

                                    if (text.Text.Trim().Contains("Email"))
                                    {
                                        text.Text = text.Text.Trim().Replace("Email",
                                            organization.Personality.Email);
                                    }

                                    if (text.Text.Trim().Contains("Identifier"))
                                    {
                                        text.Text = text.Text.Trim().Replace("Identifier",
                                            organization.Personality.Identifier);
                                    }

                                    if (text.Text.Trim().Contains("BankRekviziti"))
                                    {
                                        text.Text = text.Text.Trim().Replace("BankRekviziti", organization.Personality.BankAccounts.FirstOrDefault()?.Get() ?? "");
                                    }
                                }
                            }
                        }
                    }
                }

                wordDoc.Close();

                mem.Seek(0, SeekOrigin.Begin);

                return new DownloadFileResult
                {
                    ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    Filename = "Заявление.docx",
                    Stream = mem
                };

            }

            private static TableRow CreateTechnicRow(TechnicBaseDto technic, RunProperties runProperties)
            {
                return new TableRow(
                                 new TableCell(new Paragraph(new Run(new Text($"{technic.TechModel}")) { RunProperties = (RunProperties)runProperties.Clone() })),
                                 new TableCell(new Paragraph(new Run(new Text($"{technic.Price}")) { RunProperties = (RunProperties)runProperties.Clone() })),
                                 new TableCell(new Paragraph(new Run(new Text($"{technic.Count}")) { RunProperties = (RunProperties)runProperties.Clone() })),
                                 new TableCell(new Paragraph(new Run(new Text($"{technic.Provider}")) { RunProperties = (RunProperties)runProperties.Clone() }))
                );
            }

            private static TableRow CreateCalcCoFinancingRow(decimal coFinancing, RunProperties runProperties)
            {
                return new TableRow(
                                 new TableCell(new Paragraph(new Run(new Text("первый лизинговый платеж, производимый до передачи предмета лизинга")) { RunProperties = (RunProperties)runProperties.Clone() })),
                                 new TableCell(new Paragraph(new Run(new Text($"{coFinancing}% от общей стоимости предмета лизинга")) { RunProperties = (RunProperties)runProperties.Clone() }))
                );
            }

            private static TableRow CreateCalcPeriodRow(decimal rate, int period, RunProperties runProperties)
            {
                return new TableRow(
                                 new TableCell(
                                     new Paragraph(new Run(new Text($"ставка вознаграждения АО «КазАгроФинанс» {rate} % годовых")) { RunProperties = (RunProperties)runProperties.Clone() }),
                                     new Paragraph(new Run(new Text("(*устанавливается в зависимости от предлагаемого продукта)")) { RunProperties = (RunProperties)runProperties.Clone() })
                                    ),
                                 new TableCell(new Paragraph(new Run(new Text($"срок лизинга до {period} лет")) { RunProperties = (RunProperties)runProperties.Clone() }))
                );
            }

            private static TableRow CreateProvisionRow(ProvisionDto provision, RunProperties runProperties)
            {
                return new TableRow(
                                 new TableCell(new Paragraph(new Run(new Text($"{provision.Type}")) { RunProperties = (RunProperties)runProperties.Clone() })),
                                 new TableCell(new Paragraph(new Run(new Text($"{provision.Description}")) { RunProperties = (RunProperties)runProperties.Clone() })),
                                 new TableCell(new Paragraph(new Run(new Text($"{provision.Sum}")) { RunProperties = (RunProperties)runProperties.Clone() }))
                                 
                );
            }
        }
    }
}
