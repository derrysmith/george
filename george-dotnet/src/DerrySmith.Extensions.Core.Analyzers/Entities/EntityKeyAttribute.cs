using System;
using System.Collections.Generic;

namespace DerrySmith.Extensions.Core.Entities;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Struct)]
public sealed class EntityKeyAttribute : Attribute
{
	/// <summary>
	/// 
	/// </summary>
	public string Prefix { get; set; } = string.Empty;

	/// <summary>
	/// 
	/// </summary>
	public string Suffix { get; set; } = string.Empty;
}