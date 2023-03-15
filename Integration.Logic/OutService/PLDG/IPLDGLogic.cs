using Agro.Integration.Logic.Models.PLDG;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.PLDG
{
    public interface IPLDGLogic
    {
        Task<List<SimpleLongDto>> GetGeonim(long id);
        Task<AsonAllAtsDto> GetAts(long id);
        Task<List<SimpleLongDto>> GetAtsTypes();
        Task<bool> IsGeonimExist(long atsId, long geonimId);
        Task<PLDGPriceDto> GetPropertyPrice(PledgeDto pledge);
        Task<List<SimpleLongDto>> GetWallMaterials();
    }
}
