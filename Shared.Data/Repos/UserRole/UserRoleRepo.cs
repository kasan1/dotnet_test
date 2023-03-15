using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.UserRole
{
    public class UserRoleRepo : BaseRepo<Context.UserRole>, IUserRoleRepo
    {
        public UserRoleRepo(DataContext context) : base(context)
        {
        }
    }
}
