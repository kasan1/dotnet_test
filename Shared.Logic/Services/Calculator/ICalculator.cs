using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Calculator;

namespace Agro.Shared.Logic.Services.Calculator
{
    public interface ICalculator
    {
        decimal GetRate(RateInput rateInput);

        Task<CalculatorResult> Calculate(CalculatorInput calculatorInput);
    }
}
