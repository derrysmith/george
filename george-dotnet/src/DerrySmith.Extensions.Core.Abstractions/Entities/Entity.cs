namespace DerrySmith.Extensions.Core.Entities;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntityKey"></typeparam>
public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	/// <summary>
	/// 
	/// </summary>
	public TEntityKey Id { get; protected set; } = default!;
}