using System;

namespace DerrySmith.Extensions.Core.Entities;

public static class EntityKeyExtensions
{
	public static string ExtractEntityKeyRawValue(string value, string prefix, string suffix)
	{
		var entityKeyRawValue = value;

		if (!string.IsNullOrEmpty(prefix) && !value.StartsWith(prefix))
			throw new ArgumentException($"Cannot parse '{value}', does not start with '{prefix}'.");

		if (!string.IsNullOrEmpty(suffix) && !value.EndsWith(suffix))
			throw new ArgumentException($"Cannot parse '{value}', does not end with '{suffix}'.");

		if (!string.IsNullOrEmpty(prefix) && value.StartsWith(prefix))
			entityKeyRawValue = entityKeyRawValue.Substring(prefix.Length);

		if (!string.IsNullOrEmpty(suffix) && value.EndsWith(suffix))
			entityKeyRawValue = entityKeyRawValue.Substring(0, entityKeyRawValue.Length - suffix.Length);

		return entityKeyRawValue;
	}
}