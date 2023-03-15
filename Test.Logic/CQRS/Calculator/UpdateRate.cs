using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Agro.Shared.Logic.Services.Calculator;
using Agro.Shared.Logic.Models.Calculator;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Agro.Okaps.Logic.CQRS.Calculator
{
    public class UpdateRate
    {
        public class UpdateRateCommand : IRequest<Response<Unit>>
        {

        }

        public class CommandHandler : IRequestHandler<UpdateRateCommand, Response<Unit>>
        {
            private readonly ICalculator _calculator;
            private readonly DataContext _dataContext;

            public CommandHandler(ICalculator calculator, DataContext dataContext)
            {
                _calculator = calculator;
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
            {
                var models = await _dataContext.DicCountryTechModels
                    .Include(x => x.DicCountry)
                    .Include(x => x.DicTechModel)
                        .ThenInclude(m => m.DicTechProduct)
                    .ToListAsync();

                var techTypes = await _dataContext.DicTechTypes.ToListAsync();

                foreach (var model in models)
                {
                    var techSubType = techTypes.FirstOrDefault(x => x.Id == model.DicTechModel.DicTechProduct.DicTechTypeId);
                    model.Rate = _calculator.GetRate(new RateInput
                    {
                        DicCountryCode = model.DicCountry.Code,
                        DicTechSubTypeCode = techSubType?.Code,
                        DicTechTypeCode = techTypes.FirstOrDefault(x => x.Id == techSubType?.ParentId)?.Code
                    });
                }
                await _dataContext.SaveChangesAsync();
                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
