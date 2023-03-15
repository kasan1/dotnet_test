using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.CalculatorRepo
{
    public class Calculator:BaseRepo<Context.Calculator>,ICalculator
    {
        public Calculator(DataContext context) : base(context)
        {
        }
       

      
    }
}
