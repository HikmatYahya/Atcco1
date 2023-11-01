using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class EnumHelper
{
	public static string GetDisplayName(Enum value)
	{
		var fieldInfo = value.GetType().GetField(value.ToString());
		if (fieldInfo != null)
		{
			var displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
			if (displayAttribute != null)
			{
				return displayAttribute.Name;
			}
		}
		return value.ToString(); // Fallback to enum name if no display name is found.
	}
}
