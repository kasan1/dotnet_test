using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Calculator;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Logic.Services.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly DataContext _dataContext;

        private const decimal unitPriceLimit = 25 * 1000000;

        // Country codes
        private const string _kazakhstanCode = "KAZ";
        private const string _belarusCode = "BLR";
        private const string _chinaCode = "CHN";

        // Tech type codes
        private const string _agriculturalMachineryCode = "1";
        private const string _specialEquipmentCode = "5";
        private const string _vehicleCode = "14";

        // Subtech type codes
        private const string _equipmentCode = "10";
        private const string _selfPropMachineCode = "3";
        private const string _mountedAndTrailedMachineCode = "6";

        public Calculator(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public decimal GetRate(RateInput rateInput)
        {
            if (rateInput.DicCountryCode == _kazakhstanCode)
                return 6;
            else if (rateInput.DicCountryCode == _belarusCode ||
                    new[] { _specialEquipmentCode, _vehicleCode }.Contains(rateInput.DicTechTypeCode) ||
                    _equipmentCode == rateInput.DicTechSubTypeCode)
                return 17;
            else
                return 9;
        }

        public async Task<CalculatorResult> Calculate(CalculatorInput calculatorInput)
        {
            var techType = await _dataContext.DicTechTypes.FirstOrDefaultAsync(x => x.Id == calculatorInput.TechTypeId);
            if (techType == null)
                throw new RestException(HttpStatusCode.BadRequest, "Неверно указан тип техники");

            var techSubType = await _dataContext.DicTechTypes.FirstOrDefaultAsync(x => x.Id == calculatorInput.TechSubTypeId);
            if (techSubType == null)
                throw new RestException(HttpStatusCode.BadRequest, "Неверно указан подтип техники");

            var country = await _dataContext.DicCountries.FirstOrDefaultAsync(x => x.Id == calculatorInput.CountryId);
            if (country == null)
                throw new RestException(HttpStatusCode.BadRequest, "Страна указана неверно");

            var result = new CalculatorResult();

            #region Rate

            result.Rate = GetRate(new RateInput
            {
                DicCountryCode = country.Code,
                DicTechSubTypeCode = techSubType.Code,
                DicTechTypeCode = techType.Code
            });

            #endregion

            #region SoFinance

            if (country.Code == _chinaCode || new[] { _specialEquipmentCode, _vehicleCode }.Contains(techType.Code) || _selfPropMachineCode == techSubType.Code)
                result.CoFinancing = 25;
            else
                result.CoFinancing = 20;

            #endregion

            #region Period
            // TODO: Clarify some mements and apply changes
            if ((techType.Code == _agriculturalMachineryCode && techSubType.Code == _mountedAndTrailedMachineCode && calculatorInput.Price < unitPriceLimit)
                || (country.Code == _chinaCode && new[] { _agriculturalMachineryCode, _specialEquipmentCode, _vehicleCode }.Contains(techType.Code)))
            {
                result.Period = 5;
            }
            else if ((techType.Code == _agriculturalMachineryCode && ((techSubType.Code == _mountedAndTrailedMachineCode && calculatorInput.Price >= unitPriceLimit)
                    || (techSubType.Code == _selfPropMachineCode && calculatorInput.Price < unitPriceLimit)))
                || (country.Code != _chinaCode && new[] { _specialEquipmentCode, _vehicleCode }.Contains(techType.Code)))
            {
                result.Period = 7;
            }
            else if ((techType.Code == _agriculturalMachineryCode && techSubType.Code == _selfPropMachineCode && calculatorInput.Price >= unitPriceLimit)
                || techType.Code == _vehicleCode || techSubType.Code == _equipmentCode)
            {
                result.Period = 10;
            }
            else
            {
                result.Period = 3;
            }

            #endregion

            result.Sum = calculatorInput.Price * calculatorInput.Count;
            if (calculatorInput.Accessories != null)
                foreach (var accessory in calculatorInput.Accessories)
                    result.Sum += accessory.Price * accessory.Count;

            return result;
        }

    }
}
