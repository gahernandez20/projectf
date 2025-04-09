using System.Reflection;

namespace ProjectF.Core.Extensions;

public static class EnumExtensions
{
    public static string GetLabel(this Enum value)
        => value.GetType()
                .GetField(value.ToString())?
                .GetCustomAttribute<EnumLabel>()?
                .Label ?? value.ToString();
    
    public static List<PlayerType> GetBackfield()
        => Enum.GetValues<PlayerType>()
               .Where(value => value.GetType()
                                              .GetField(value.ToString())?
                                              .GetCustomAttribute<Backfield>() is not null)
               .ToList();

    public static List<TEnum> GetValuesWithAttribute<TEnum, TAttribute>()
        where TEnum : Enum
        where TAttribute : Attribute
        => Enum.GetValues(typeof(TEnum))
               .Cast<TEnum>()
               .Where(value => value.GetType()
                                           .GetField(value.ToString())?
                .GetCustomAttribute<TAttribute>() is not null).ToList();
}