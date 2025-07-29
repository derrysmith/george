namespace DerrySmith.Extensions.Core.Entities;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TAggRootKey"></typeparam>
public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot;