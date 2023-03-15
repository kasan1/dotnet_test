using System;
using Agro.Shared.Data.Attributes;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Shared.Data.Extensions.Enums
{
    public static class RoleEnumExtensions
    {
        public static Guid Id(this RoleType roleEnum)
        {
            return roleEnum.GetAttribute<RoleType, DirectoryAttribute>().Id;
        }

        public static string SystemName(this RoleType roleEnum)
        {
            return roleEnum.GetAttribute<RoleType, DirectoryAttribute>().SystemName;
        }
    }
}
