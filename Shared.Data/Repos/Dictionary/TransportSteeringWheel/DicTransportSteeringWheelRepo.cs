using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.TransportSteeringWheel
{
    public class DicTransportSteeringWheelRepo : BaseRepo<DicTransportSteeringWheel>, IDicTransportSteeringWheelRepo
    {
        public DicTransportSteeringWheelRepo(DataContext context) : base(context)
        {
        }
    }

}
