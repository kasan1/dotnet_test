using Agro.Integration.Logic.Models.PLDG;
using Agro.Shared.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.PLDG
{
    public class PLDGLogic : IPLDGLogic
    {
        private readonly IOptions<AppSettings> _conf;
        public PLDGLogic(IOptions<AppSettings> conf)
        {
            _conf = conf;
        }

        public async Task<List<SimpleLongDto>> GetGeonim(long id)
        {
            try
            {
                var _client = new ProOsenka.AppraisalClient();
                var _ = await _client.GetEgovGEONIMAsync(GetHeader(), id);
                return  _.list.Select(x => new SimpleLongDto
                {
                    Id = x.ID,
                    Name = x.Name
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении данных из АСОН(GetGeonim): " + e.Message);
            }
        }

        public async Task<AsonAllAtsDto> GetAts(long id)
        {
            try
            {
                var data = new AsonAllAtsDto();
                var _client = new ProOsenka.AppraisalClient();
                var _ = await _client.GetEgovATSAsync(GetHeader(), id);
                data.All = _.list
                    .OrderBy(x => x.Name)
                    .Select(x => new AsonSimpleAtsDto()
                    {
                        Id = x.ID,
                        Name = x.Name,
                        Type = x.Type,
                        Cato = x.Cato
                    }).ToList();
                var dataTypes = data.All.Select(y => y.Type).Distinct();
                var allTypes = await GetAtsTypes();
                var _allTypes = allTypes.Where(x => dataTypes.Contains(x.Id)).Select(x => x.Name).ToList();

                if (dataTypes.Contains(1))
                {
                    var streets = await GetGeonim(id);
                    if (streets.Any())
                    {
                        data.All.AddRange(streets.Select(x => new AsonSimpleAtsDto()
                        {
                            Id = x.Id,
                            Name = x.Name
                        }));
                        _allTypes.Add("УЛИЦА");
                    }
                }
                data.Types = string.Join("/", _allTypes);
                return data;
            }

            catch (Exception e)
            {
                throw new Exception("Ошибка при получении данных из АСОН(GetAts): " + e.Message);
            }
        }

        public async Task<List<SimpleLongDto>> GetAtsTypes()
        {
            try
            {
                var _client = new ProOsenka.AppraisalClient();
                var _ = await _client.GetEgovATSTypeAsync(GetHeader());
                return _.list
                .OrderBy(x => x.Name)
                .Select(x => new SimpleLongDto()
                {
                    Id = x.ID,
                    Name = x.Name
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении данных из АСОН(GetAtsTypes): " + e.Message);
            }
        }

        public async Task<bool> IsGeonimExist(long atsId, long geonimId)
        {
            try
            {
                var geonims = await GetGeonim(atsId);
                var geonim = geonims.Any(x => x.Id == geonimId);
                return geonim;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении данных из АСОН(IsGeonimExist): " + e.Message);
            }
        }

        public async Task<List<SimpleLongDto>> GetWallMaterials()
        {
            try
            {
                var _client = new ProOsenka.AppraisalClient();
                var wallMaterials = await _client.GetWallMaterialsAsync(GetHeader());
                var _wallMaterials = wallMaterials.wallMaterials
                    .Select(x => new SimpleLongDto()
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
                return _wallMaterials;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ошибка при получении видов материалов из АСОН(GetWallMaterials): " + e.Message);
            }
        }

        public async Task<PLDGPriceDto> GetPropertyPrice(PledgeDto pledge)
        {
            var result = new PLDGPriceDto();            
            try
            {
                var _client = new ProOsenka.AppraisalClient();
                var propertyPriceRequest = new ProOsenka.PropertyPriceRequest()
                {
                    AtsID = pledge.AtsID,
                    GeonimID = pledge.GeonimID,
                    HouseNumber = pledge.HouseNumber,
                    RealtyType = pledge.RealtyType,
                    RoomNumber = pledge.RoomNumber,
                    WallMaterial = pledge.WallMaterial,
                    YearBuilt = pledge.YearBuilt
                };
                var propertyPriceResponse = await _client.GetPropertyPriceAsync(GetHeader(), propertyPriceRequest);
                if (propertyPriceResponse == default)
                    return null;

                switch (propertyPriceResponse.PriceType)
                {
                    case 1:
                        result.PriceType = PriceType.MultiplySquare;
                        result.SquarePrice = propertyPriceResponse.Price;
                        result.TotalSum = propertyPriceResponse.Price * pledge.TotalSquare;
                        break;
                    case 2:
                        result.PriceType = PriceType.All;
                        result.TotalSum = propertyPriceResponse.Price;
                        break;
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении данных из АСОН(GetPropertyPrice): " + e.Message);
            }
        }

        private ProOsenka.RequestHeader GetHeader()
        {
            return new ProOsenka.RequestHeader
            {
                UserName = _conf.Value.Integrations.PLDG.Login,
                Password = _conf.Value.Integrations.PLDG.Password
            };
        }

    }
}
