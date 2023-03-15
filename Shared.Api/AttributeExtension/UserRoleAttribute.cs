using Agro.Shared.Data.Enums.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agro.Shared.Api.AttributeExtension
{
    /// <summary>
    /// Расширение для 
    /// </summary>
    public class UserRoleAttributeExtension : AuthorizeAttribute
    {
        public UserRoleAttributeExtension(params RoleType[] roles)
        {
            Roles = string.Join(",", roles.Select(x => (int)x));
        }
    }
}
