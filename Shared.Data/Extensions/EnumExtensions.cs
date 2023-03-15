using System;
using System.Linq;

namespace Agro.Shared.Data.Extensions
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TEnum, TAttribute>(this TEnum enumValue)
            where TAttribute : Attribute
            where TEnum : Enum
        {
            var enumType = enumValue.GetType();
            var fieldName = Enum.GetName(enumType, enumValue);
            return enumType.GetField(fieldName).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }
}
