using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Logic;
using Microsoft.AspNetCore.Authorization;

namespace Agro.Shared.Api.Controllers
{
    [AllowAnonymous]
    public class PrintController : BaseController
    {
        private readonly ILoanApplicationRepo _loanAppRepo;
        private readonly IPrintLogic _printLogic;


        public PrintController(IPrintLogic printLogic, ILoanApplicationRepo loanAppRepo
            )
        {
            _printLogic = printLogic;
            _loanAppRepo = loanAppRepo;
        }

        //[HttpPost("GenerateFile")]
        //public IActionResult GenerateFile([FromBody] PrintInDto model)
        //{
        //    model.XmlData = GetXmlData(model).ToString();

        //    var buffer = _printLogic.Generate(model);

        //    if (buffer == null)
        //        return NotFound();

        //    return new FileContentResult(buffer, model.Format) // Need to apply correct model.Format
        //    {
        //        FileDownloadName = model.Name + "." + model.Format
        //    };
        //}

        //private XElement GetXmlData(PrintInDto model)
        //{
        //    XElement xData;

        //    switch (model.Name)
        //    {
        //        case "ManagerConclusion": xData = GetXmlManagerConclusion(model); break;
        //        case "ManagerConclusionAccept": xData = GetXmlManagerConclusionAccept(model); break;
        //        case "ManagerConclusionReject": xData = GetXmlManagerConclusionReject(model); break;
        //        default: xData = new XElement("Root"); break;
        //    }

        //    return xData;
        //}

        //private XElement GetXmlManagerConclusionAccept(PrintInDto model)
        //{
        //    XElement xRoot = new XElement("Root");
        //    if (!string.IsNullOrEmpty(model.XmlData))
        //        xRoot.Add(XElement.Parse(model.XmlData));

        //    var loan = _loanAppRepo.GetQueryable(x => x.Id == model.AppId).AsNoTracking()
        //    .Select(x => new
        //    {
        //        ClientFullName = x.User.FullName,
        //        CreatedDate = x.CreatedDate,
        //        RegNumber = x.RegNumber,
        //        BranchNameRu = "x.User.Branch.NameRu"
        //    }).FirstOrDefault();
        //    xRoot.Add(new XElement("Client", new XElement("FullName", loan.ClientFullName)),
        //                new XElement("App",
        //                    new XElement("City", loan.BranchNameRu),
        //                    new XElement("Regnum", loan.RegNumber),
        //                    new XElement("CreateDate", loan.CreatedDate.ToShortDateString())
        //                )
        //        );

        //    return xRoot;
        //}
        //private XElement GetXmlManagerConclusionReject(PrintInDto model)
        //{
        //    XElement xRoot = new XElement("Root");
        //    if (!string.IsNullOrEmpty(model.XmlData))
        //        xRoot.Add(XElement.Parse(model.XmlData));

        //    var loan = _loanAppRepo.GetQueryable(x => x.Id == model.AppId).AsNoTracking()
        //    .Select(x => new
        //    {
        //        ClientFullName = x.User.FullName,
        //        CreatedDate = x.CreatedDate,
        //        RegNumber = x.RegNumber,
        //        BranchNameRu = "x.User.Branch.NameRu"
        //    }).FirstOrDefault();
        //    xRoot.Add(new XElement("Client", new XElement("FullName", loan.ClientFullName)),
        //                new XElement("App",
        //                    new XElement("City", loan.BranchNameRu),
        //                    new XElement("Regnum", loan.RegNumber),
        //                    new XElement("CreateDate", loan.CreatedDate.ToShortDateString())
        //                )
        //        );

        //    return xRoot;
        //}
        //private XElement GetXmlManagerConclusion(PrintInDto model)
        //{
        //    XElement xRoot = new XElement("Root");
        //    if (!string.IsNullOrEmpty(model.XmlData))
        //        xRoot.Add(XElement.Parse(model.XmlData));

        //    var loan = _loanAppRepo.GetQueryable(x => x.Id == model.AppId).AsNoTracking()
        //    .Select(x => new
        //    {
        //        ClientFullName = x.User.FullName,
        //        CreatedDate = x.CreatedDate,
        //        RegNumber = x.RegNumber,
        //        BranchNameRu = "x.User.Branch.NameRu"
        //    }).FirstOrDefault();

        //    XElement xIncomes = new XElement("Incomes");
        //    XElement xCredits = new XElement("Credits");
        //    XElement xPledges = new XElement("Pledges");

        //    for (int i = 0; i < 0; i++)
        //    {
        //        xIncomes.Add(new XElement("Income",
        //            new XElement("Year", ""),
        //            new XElement("Amount", "")
        //            ));
        //    }
        //    xIncomes.Add(new XElement("Amounts", ""));


        //    for (int i = 0; i < 0; i++)
        //    {
        //        xCredits.Add(new XElement("Credit",
        //            new XElement("No", ""),
        //            new XElement("Number", ""),
        //            new XElement("Date", ""),
        //            new XElement("Amount", ""),
        //            new XElement("Balance", ""),
        //            new XElement("Percent", ""),
        //            new XElement("Term", ""),
        //            new XElement("MonthAmount", ""),
        //            new XElement("Restruct", "")
        //            ));
        //    }

        //    for (int i = 0; i < 0; i++)
        //    {
        //        xPledges.Add(new XElement("Pledge",
        //            new XElement("No", ""),
        //            new XElement("Type", ""),
        //            new XElement("Owner", ""),
        //            new XElement("Address", ""),
        //            new XElement("Noksum", ""),
        //            new XElement("PledgeSum", "")
        //            ));
        //    }
        //    xPledges.Add(new XElement("NokSums", ""),
        //        new XElement("PledgeSums", ""));

        //    XElement xClient = new XElement("Client",
        //                    new XElement("City", loan.BranchNameRu),
        //                    new XElement("Date", "____20__"),
        //                            new XElement("FullName", loan.ClientFullName),
        //                            new XElement("Address", ""),
        //                            new XElement("Phone", ""),
        //                            new XElement("OwnType", ""),
        //                            new XElement("Activity", ""),
        //                            new XElement("FamilyCount", ""),
        //                            xIncomes
        //                            );

        //    XElement xApp = new XElement("App",
        //                        new XElement("Regnum", loan.RegNumber),
        //                        new XElement("CreateDate", loan.CreatedDate.ToShortDateString()),
        //                        new XElement("Purpose", ""),
        //                        new XElement("Term", ""),
        //                        new XElement("Percent", ""),
        //                        new XElement("PledgeType", ""),
        //                        new XElement("Desc", ""),
        //                        new XElement("CredManager", "_______________________"),
        //                        new XElement("CredAdmin", "_______________________")
        //                        );

        //    xRoot.Add(xClient,
        //               xApp,
        //               xCredits,
        //               xPledges);

        //    return xRoot;
        //}

        /*
        [HttpPost("GetCliInfoForStatement")]
        public async Task<object> GetCliInfoForStatement(PrintInDto model)
        {
            //PrintInDto model = new PrintInDto();
            model.Name = "test";
            model.Format = "pdf";
            model.HasXml = true;
            var loan =  _loanAppRepo.GetQueryable(x => x.Id == model.ApplicationId)
                .Select(x => new
                {   x.UserId,
                    x.PurposeDetail,
                    x.RegNumber,
                    loanPurposeKz = x.DicLoanPurpose.NameKz,
                    loanPurposeRu = x.DicLoanPurpose.NameRu,
                    loanppoductkz = x.DicLoanProducts.NameKz,
                    loanProductRu = x.DicLoanProducts.NameRu,
                    ClientFullName = x.User.FullName
                }).FirstOrDefault();
            
            var loanCondition = _condition.GetQueryable(x => x.LoanApplicationId == model.ApplicationId)
                .Select(x => new
                {
                    x.Amount,
                    x.Duration, //срок займа 
                    Method = x.Method==2?"Дифферинцированный":"Аннуитетный", // метод погашения 
                    x.PeriodOd,  //льготный период по ОД 
                    x.PeriodPercent,//льготный период по % 
                    x.PaymentOd, //периодичность погашенгие раз в полгода или в год  ОД
                    x.PaymentPercent, // периодичность погашенгие раз в полгода или в год  %
                    x.PaymentDate,  
                    createDate = x.LoanApplication.CreatedDate
                }).FirstOrDefault();
            
            var cliInfo = _userRepo.GetQueryable(x => x.Id == loan.UserId)
                 .Select(x => new
                 {
                     branchNameKz = x.Branch.NameKz,
                     branchNameRu = x.Branch.NameRu
                 }).FirstOrDefault(); 


            XElement xmlTree1 = new XElement("Root",
                                        new XElement("ClientFullName", loan.ClientFullName),
                                        new XElement("Amount", loanCondition.Amount),
                                        new XElement("Duration", loanCondition.Duration),
                                        new XElement("loanPurposeRu", loan.loanPurposeRu),
                                        new XElement("loanPurposeKz", loan.loanPurposeKz),
                                        new XElement("PurposeDetail", loan.PurposeDetail),
                                        new XElement("PeriodOd", loanCondition.PeriodOd),
                                        new XElement("PeriodPercent", loanCondition.PeriodPercent),
                                        new XElement("PaymentPercent", loanCondition.PaymentPercent),
                                        new XElement("Method", loanCondition.Method),
                                        new XElement("branchNameKz", cliInfo.branchNameKz),
                                        new XElement("branchNameRu", cliInfo.branchNameRu),
                                        new XElement("createDate", loanCondition.createDate)

                                        );

            model.XmlData = xmlTree1.ToString();
            var buffer = _printLogic.Generate(model);
            if (buffer == null)
                return NotFound();
            return new FileContentResult(buffer, ContentTypeHelper.GetContentType("." + model.Format))
            {
                FileDownloadName = "test.pdf"
            };
        }


        [HttpPost("GetDataForAnketa")]
        public async Task<object> GetDataForAnketa(PrintInDto model)
        {
            //PrintInDto model = new PrintInDto();
            model.Name = "test";
            model.Format = "pdf";
            model.HasXml = true;
            var loan = _loanAppRepo.GetQueryable(x => x.Id == model.ApplicationId)
                .Select(x => new
                {   x.UserId,
                    ClientFullName = x.User.FullName,
                }).FirstOrDefault();

            var clientInfo = _cliProfileRepo.GetQueryable(x => x.UserId == loan.UserId)
                .Select(x => new
                {
                    x.MaritalStatus,
                    x.RegistrationAddressKz,
                    x.RegistrationAddressRu
                });


            var pledge = _basePledgeRepo.GetQueryable(x => x.ApplicationId == model.ApplicationId)
                .Select(x => new
                {
                    x.ExpertSum
                });

            XElement xmlTree1 = new XElement("Root",
                                        new XElement("ClientFullName", loan.ClientFullName)

                                        );

            model.XmlData = xmlTree1.ToString();
            var buffer = _printLogic.Generate(model);
            if (buffer == null)
                return NotFound();
            return new FileContentResult(buffer, ContentTypeHelper.GetContentType("." + model.Format))
            {
                FileDownloadName = "test.pdf"
            };
        }

        */
    }
}