using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.Enums.WordReports;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.System;
using DocumentFormat.OpenXml.Packaging;
using MediatR;
using Microsoft.Extensions.Hosting;
using DocumentFormat.OpenXml.Wordprocessing;
using Agro.Shared.Logic.Extensions;
using Agro.Bpm.Logic.CQRS.ReportDocuments.DTOs;

namespace Agro.Bpm.Logic.CQRS.ReportDocuments.Word
{
    public class MinutesOfCreditCommitteeMeetingWordProtocol
    {
        public class Query : IRequest<Response<DownloadFileResult>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<DownloadFileResult>>
        {
            private readonly IHostEnvironment _hostEnvironment;
            private readonly IMediator _mediator;

            private const string _templateFilename = "CreditCommitteeProtocol.docx";

            public QueryHandler(IHostEnvironment hostEnvironment, IMediator mediator)
            {
                _hostEnvironment = hostEnvironment;
                _mediator = mediator;
            }

            public async Task<Response<DownloadFileResult>> Handle(Query request, CancellationToken cancellationToken)
            {
                var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "docs", "templates", _templateFilename);
                if (!File.Exists(filePath))
                    throw new Exception("Template file was not specified");

                byte[] byteArray = File.ReadAllBytes(filePath);
                var mem = new MemoryStream();
                mem.Write(byteArray, 0, byteArray.Length);

                WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true);
                var body = wordDoc.MainDocumentPart.Document.Body;

                var result = await _mediator.Send(new MinutesOfCreditCommitteeMeeting.Query() { LoanApplicationId = request.LoanApplicationId });

                var regions = body.Descendants<Text>().Where(t => t.InnerText.Contains("region"));
                foreach (var region in regions)
                {
                    // TODO: Conjugate 
                    region.CheckAndReplaceText("region", result.Data.Region);
                }
                body.FindParagraphAndReplaceText("[region]", result.Data.Region);

                var protocolNumber = body.Descendants<Text>().FirstOrDefault(t => t.InnerText.Contains("number"));
                protocolNumber.CheckAndReplaceText("number", result.Data.ProtocolNumber);

                var city = body.Descendants<Text>().FirstOrDefault(t => t.InnerText.Contains("city"));
                city.CheckAndReplaceText("city", result.Data.City);

                var date = body.Descendants<Text>().FirstOrDefault(t => t.InnerText.Contains("date"));
                date.CheckAndReplaceText("date", result.Data.LastVotedDate);

                FillParticipantsTable(body, result.Data);

                var applicantName = body.Descendants<Text>().FirstOrDefault(t => t.InnerText.Contains("applicantname"));
                applicantName.CheckAndReplaceText("applicantname", result.Data.ApplicantName);
                body.FindParagraphAndReplaceText("[applicantname]", result.Data.ApplicantName);

                var applicantAddress = body.Descendants<Text>().FirstOrDefault(t => t.InnerText.Contains("applicantaddress"));
                applicantAddress.CheckAndReplaceText("applicantaddress", result.Data.ApplicantAddress);

                body.FindParagraphAndReplaceText("[reporterPosition]", result.Data.Reporter.Position);
                body.FindParagraphAndReplaceText("[reporterFullname]", result.Data.Reporter.Fullname);                

                FillConditionsTable(CreditCommitteeTable.RequestedConditions, body, result.Data.RequestedConditions);

                body.FindParagraphAndReplaceText("[riskManagementDepartmentConclusion]", result.Data.RiskManagementDepartmentConclusion ? "положительное" : "отрицательное");
                body.FindParagraphAndReplaceText("[legalDepartmentConclusion]", result.Data.LegalDepartmentConclusion ? "положительное" : "отрицательное");
                body.FindParagraphAndReplaceText("[securityDepartmentConclusion]", result.Data.SecurityDepartmentConclusion ? "положительное" : "отрицательное");

                FillConditionsTable(CreditCommitteeTable.ProvidedConditions, body, result.Data.ProvidedConditions);

                FillVoteResultsTable(body, result.Data);

                wordDoc.Close();

                mem.Seek(0, SeekOrigin.Begin);

                return Response.Success("Протокол успешно сформирован", new DownloadFileResult
                {
                    ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    Filename = $"Протокол Кредитного Комитета №{result.Data.ProtocolNumber}.docx",
                    Stream = mem
                });
            }

            private void FillParticipantsTable(Body body, CreditCommitteeMeetingDto dto)
            {
                var participantsTable = body.Elements<Table>().ElementAt((int)CreditCommitteeTable.Participants);

                participantsTable.FindParagraphAndReplaceText("[presidedPersonPosition]", dto.Presided.Position);
                participantsTable.FindParagraphAndReplaceText("[presidedPersonFullname]", dto.Presided.Fullname);

                dto.CreditCommitteeMembers.ForEach(member =>
                {
                    var positionRunProperties = new RunProperties() { FontSize = new FontSize() { Val = "20" } };
                    var fullnameRunProperties = new RunProperties() { FontSize = new FontSize() { Val = "20" } };
                    participantsTable.Append(new TableRow(
                        new TableCell(new Paragraph(new Run(positionRunProperties, new Text(member.Position)))),
                        new TableCell(new Paragraph(new Run(fullnameRunProperties, new Text(member.Fullname))))
                    ));
                });
            }

            private void FillConditionsTable(CreditCommitteeTable creditCommitteeTable, Body body, ConditionDto dto)
            {
                var requestedConditionsTable = body.Elements<Table>().ElementAt((int)creditCommitteeTable);

                requestedConditionsTable.FindParagraphAndReplaceText("[creditProduct]", dto.CreditProduct);
                requestedConditionsTable.FindParagraphAndReplaceText("[lizingSubject]", dto.LizingSubject);
                requestedConditionsTable.FindParagraphAndReplaceText("[supplier]", dto.Supplier);
                requestedConditionsTable.FindParagraphAndReplaceText("[financeSource]", dto.FinanceSource);
                requestedConditionsTable.FindParagraphAndReplaceText("[sum]", dto.Sum.ToString("N2"));
                requestedConditionsTable.FindParagraphAndReplaceText("[coFinancing]", dto.CoFinancing);
                requestedConditionsTable.FindParagraphAndReplaceText("[period]", dto.Period);
                requestedConditionsTable.FindParagraphAndReplaceText("[rate]", dto.Rate);
                requestedConditionsTable.FindParagraphAndReplaceText("[indexing]", dto.Indexing);
                requestedConditionsTable.FindParagraphAndReplaceText("[principalDebtRepaymentProcedure]", dto.PrincipalDebtRepaymentProcedure);
                requestedConditionsTable.FindParagraphAndReplaceText("[rewardsRepaymentProcedure]", dto.RewardsRepaymentProcedure);
                requestedConditionsTable.FindParagraphAndReplaceText("[projectReviewCommission]", dto.ProjectReviewCommission);
                requestedConditionsTable.FindParagraphAndReplaceText("[deliveryPoint]", dto.DeliveryPoint);
                requestedConditionsTable.FindParagraphAndReplaceText("[profitCenter]", dto.ProfitCenter);
                requestedConditionsTable.FindParagraphAndReplaceText("[monitoringFrequency]", dto.MonitoringFrequency);
                requestedConditionsTable.FindParagraphAndReplaceText("[insurance]", dto.Insurance);
                requestedConditionsTable.FindParagraphAndReplaceText("[specialCondition]", dto.SpecialCondition);
            }

            private void FillVoteResultsTable(Body body, CreditCommitteeMeetingDto dto)
            {
                var voteResultsTable = body.Elements<Table>().ElementAt((int)CreditCommitteeTable.Votes);

                var runProperties = new RunProperties() { FontSize = new FontSize() { Val = "20" } };
                voteResultsTable.Append(new TableRow(
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(dto.Presided.Position)))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(dto.Presided.Fullname)))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(dto.Presided.Decision ? "✔" : "")))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(dto.Presided.Decision ? "" : "✔")))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(dto.Presided.Comment))))
                    ));

                dto.CreditCommitteeMembers.ForEach(member =>
                {
                    voteResultsTable.Append(new TableRow(
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(member.Position)))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(member.Fullname)))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(member.Decision ? "✔" : "")))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(member.Decision ? "" : "✔")))),
                        new TableCell(new Paragraph(new Run((RunProperties)runProperties.Clone(), new Text(member.Comment))))
                    ));
                });
            }
        }
    }
}
