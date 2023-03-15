using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Agro.Shared.Logic.Models.System;
using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using Microsoft.Extensions.Hosting;

namespace Agro.Okaps.Logic.CQRS.PaymentSchedule
{
    public class Download
    {
        public class DownloadCommand : IRequest<DownloadFileResult>
        {
            public int Period { get; set; }
            public decimal Sum { get; set; }
            public decimal CoFinancing { get; set; }
            public decimal Rate { get; set; }
        }

        public class CommandHandler : IRequestHandler<DownloadCommand, DownloadFileResult>
        {
            private readonly IHostEnvironment _hostEnvironment;

            public CommandHandler(IHostEnvironment hostEnvironment)
            {
                _hostEnvironment = hostEnvironment;
            }

            public async Task<DownloadFileResult> Handle(DownloadCommand request, CancellationToken cancellationToken)
            {
                var data = new PaymentSchedule
                {
                    Sum = request.Sum,
                    CoFinancing = request.CoFinancing / 100,
                    Period = request.Period,
                    Rate = request.Rate / 100
                };

                data.Generate();

                var templateFilename = "График_платежей_лизинг_дифференцированный_шаблон.xlsx";
                var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "docs", "templates", templateFilename);

                using ExcelPackage p = new ExcelPackage(new FileInfo(filePath));
                //Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets[0];

                ws.Cells[4, 8].Value = data.Sum;
                ws.Cells[5, 8].Value = data.Rate;
                ws.Cells[6, 8].Value = data.CountOfDaysInYear;
                ws.Cells[7, 8].Value = data.CountOfDaysInMonth;
                ws.Cells[8, 8].Value = data.CoFinancing;
                ws.Cells[9, 8].Value = data.Period;

                int index = 15;
                foreach (var item in data.Items)
                {
                    ws.Cells[index, 1].Value = item.Number;
                    ws.Cells[$"B{index}:C{index}"].Merge = true;
                    ws.Cells[index, 2].Value = item.Date.ToShortDateString();
                    if (item.MainDebt > 0)
                        ws.Cells[index, 4].Value = item.MainDebt;
                    ws.Cells[$"G{index}:H{index}"].Merge = true;
                    ws.Cells[index, 7].Value = item.Compensation;
                    ws.Cells[index, 9].Value = item.CurrentPayment;
                    ws.Cells[index, 10].Value = item.Balance;
                    index++;
                }

                ws.Cells[$"A{15}:J{index - 1}"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[$"A{index}:C{index}"].Merge = true;
                ws.Cells[$"A{index}:J{index}"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[$"A{index}:J{index}"].Style.Font.Bold = true;
                ws.Cells[index, 1].Value = "ИТОГО:";
                ws.Cells[index, 4].Value = data.Items.Sum(x => x.MainDebt);
                ws.Cells[index, 7].Value = data.Items.Sum(x => x.Compensation);
                ws.Cells[$"G{index}:H{index}"].Merge = true;
                ws.Cells[index, 9].Value = data.Items.Sum(x => x.CurrentPayment);

                return new DownloadFileResult
                {
                    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    Filename = "График платежей.xlsx",
                    Stream = new MemoryStream(p.GetAsByteArray())
                };
                //p.SaveAs(new FileInfo($@"/Users/bauyrzan/Downloads/PaymentSchedule{DateTime.Now:HHmmss}.xlsx"));
            }
        }
    }

    public class PaymentSchedule
    {
        public decimal Sum { get; set; }
        public decimal Rate { get; set; }

        public readonly int CountOfDaysInYear = 360;
        public readonly int CountOfDaysInMonth = 30;

        public decimal CoFinancing { get; set; }
        public int Period { get; set; }
        public List<PaymentScheduleItem> Items { get; set; } = new List<PaymentScheduleItem> { };



        private static DateTime GetNextMonth() => new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

        public void Generate()
        {
            var firstPayment = new PaymentScheduleItem
            {
                Number = 1,
                Date = GetNextMonth(),
            };
            firstPayment.SetPayment(0, Sum * CoFinancing);
            firstPayment.Balance = Sum - firstPayment.MainDebt;
            Items.Add(firstPayment);

            for (int i = 1; i < 1000; i++)
            {
                var payment = new PaymentScheduleItem
                {
                    Number = i + 1,
                    Date = Items.Last().Date.AddMonths(1)
                };

                decimal twoStepBefore = Items.Count > 1 ? (Items[Items.Count - 2].Balance * Rate / CountOfDaysInYear * 1) : 0;
                decimal oneStepBefore = Items.Last().Balance * Rate / CountOfDaysInYear * (CountOfDaysInMonth - 1);
                decimal mainDebt = i % 12 == 0 ? (Items.First().Balance / Period) : 0;
                payment.SetPayment(twoStepBefore + oneStepBefore, mainDebt);
                payment.Balance = Items.Last().Balance - payment.MainDebt;

                Items.Add(payment);
                if (payment.Balance <= 0)
                    break;
            }

        }
    }

    public class PaymentScheduleItem
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public decimal MainDebt { get; private set; }
        public decimal Compensation { get; private set; }
        public decimal CurrentPayment { get; set; }
        public decimal Balance { get; set; }

        public void SetPayment(decimal compensation, decimal mainDebt = 0)
        {
            Compensation = compensation;
            MainDebt = mainDebt;
            CurrentPayment = Compensation + MainDebt;
        }
    }
}
