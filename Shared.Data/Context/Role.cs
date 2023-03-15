using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Enums.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context
{
    [Table("Roles")]
    public class Role : BaseDictionary
    {
        public RoleType Value { get; set; }
        public ICollection<UserRole> UserRoles { get; private set; } = new HashSet<UserRole>();
    }
}
