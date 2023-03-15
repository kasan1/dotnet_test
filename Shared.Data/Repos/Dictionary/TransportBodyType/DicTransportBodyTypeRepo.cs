using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.TransportBodyType
{
    public class DicTransportBodyTypeRepo : BaseRepo<DicTransportBodyType>, IDicTransportBodyTypeRepo
    {
        public DicTransportBodyTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
