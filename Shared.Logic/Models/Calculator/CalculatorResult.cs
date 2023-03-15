using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Logic.Models.Calculator
{
    public class CalculatorResult
    {
        public int Period { get; set; }
        public decimal Rate { get; set; }
        public decimal CoFinancing { get; set; }
        public decimal Sum { get; set; }
        public LoanTypeEnum LoanType
        {
            get
            {
                //TODO: уточнить проценты
                if (Sum > 150 * 1000000
                    //& Rate>=15 & Rate<=50
                    )
                    return LoanTypeEnum.StandartLeasing;
                else
                    return LoanTypeEnum.ExpressLeasing;
            }
            private set { }
        }
    }
}
