namespace DS.George.Extensions.Core.Entities;

public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot;