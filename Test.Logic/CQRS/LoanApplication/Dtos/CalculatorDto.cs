namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class CalculatorDto
    {
        public int Period { get; set; }
        public decimal CoFinancing { get; set; }
        public decimal? Sum { get; set; }
        public decimal? Rate { get; set; }
    }
}
