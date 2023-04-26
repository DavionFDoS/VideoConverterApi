using System.Runtime.Serialization;

namespace VideoConverterApi.Extensions;

public static class EnumExtensions
{
    public static string GetEnumMemberValue<TEnum>(this TEnum value) where TEnum : Enum
    {
        var enumMemberAttr = typeof(TEnum)
            .GetField(value.ToString())
            .GetCustomAttributes(false)
            .OfType<EnumMemberAttribute>()
            .FirstOrDefault();

        return enumMemberAttr?.Value;
    }
}
