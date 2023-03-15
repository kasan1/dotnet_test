using System;

namespace Agro.Okaps.Logic.Models
{
    public class LoanConditionInDto
    {
        public decimal? Amount { get; set; }
        public short? Duration { get; set; }
        public short? Transh { get; set; }
        public short? Method { get; set; }
        public short? PeriodOd { get; set; }
        public short? PeriodPercent { get; set; }
        public short? PaymentOd { get; set; }
        public short? PaymentPercent { get; set; }
        public short? PaymentDay { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid? PlanId { get; set; }
    }
}