using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Agro.Shared.Logic.Services.Calculator;
using Agro.Shared.Logic.Models.Calculator;

namespace Agro.Okaps.Logic.CQRS.Calculator
{
    public class Calculate
    {
        public class Command : CalculatorInput, IRequest<Response<CalculatorResult>>
        {

        }

        public class CommandHandler : IRequestHandler<Command, Response<CalculatorResult>>
        {
            private readonly ICalculator _calculator;

            public CommandHandler(ICalculator calculator)
            {
                _calculator = calculator;
            }

            public async Task<Response<CalculatorResult>> Handle(Command request, CancellationToken cancellationToken)
            {
                return Response.Success("Запрос выполнен успешно", await _calculator.Calculate(request));
            }
        }
    }
}
