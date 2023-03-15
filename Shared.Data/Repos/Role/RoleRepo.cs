using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Role
{
    public class RoleRepo : BaseRepo<Context.Role>, IRoleRepo
    {
        public RoleRepo(DataContext context) : base(context)
        {
        }
    }
}
