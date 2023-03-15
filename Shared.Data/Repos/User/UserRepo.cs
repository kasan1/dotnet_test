using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.User
{
    public class UserRepo : BaseRepo<Context.User>, IUserRepo
    {
        public UserRepo(DataContext context) : base(context)
        {
        }
    }
}
