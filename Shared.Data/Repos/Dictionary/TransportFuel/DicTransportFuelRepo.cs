using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.TransportFuel
{
    public class DicTransportFuelRepo : BaseRepo<DicTransportFuel>, IDicTransportFuelRepo
    {
        public DicTransportFuelRepo(DataContext context) : base(context)
        {
        }
    }

}
