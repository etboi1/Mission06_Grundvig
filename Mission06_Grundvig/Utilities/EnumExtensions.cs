namespace Mission06_Grundvig.Utilities;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

// Extension to enum type to allow me to continue using the Rating enum (which is best-practice)
// but also store the rating string to the database rather than an int
public static class EnumExtensions
{
    // Helper function for extracting the display name from the enum value for storage in db
    public static string GetDisplayName(this Enum enumValue)
    {
        var member = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First();

        var display = member.GetCustomAttribute<DisplayAttribute>();

        return display?.Name ?? enumValue.ToString();
    }

    // Helper function for extracting enum value from string stored in db
    public static T FromDisplayName<T>(string displayName) where T : Enum
    {
        foreach (var value in Enum.GetValues(typeof(T)))
        {
            var enumValue = (Enum)value;
            if (enumValue.GetDisplayName() == displayName)
                return (T)value;
        }

        throw new Exception($"No enum with display name {displayName}");
    }
}
