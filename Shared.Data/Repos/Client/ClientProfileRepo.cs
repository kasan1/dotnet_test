using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Client
{
    public class ClientProfileRepo : BaseRepo<ClientProfile>, IClientProfileRepo
    {
        public ClientProfileRepo(DataContext context) : base(context)
        {
        }
    }
}
