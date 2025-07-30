## [george][1]

A set of cross-platform libraries for developing applications following Domain Driven Design and Clean Architecture principles.

```
> derrysmith/george
	> george-dotnet
		> src
			> DS.George.Extensions.Core
			> DS.George.Extensions.Core.Analyzers
			> DS.George.Extensions.Core.Common
	> george-nodejs
```

### NuGet Packages for .NET Core Development

**Defining Entities and Aggregates**

```csharp
class MyAggregateRoot : AggregateRoot<Guid>
{
}

class MyEntity : Entity<Guid>
{
}
```

**Using a Strongly-Typed Id for the Entity Identifier**

- Reference the `DerrySmith.Extensions.Core.Analyzers` package in order to utilize the strongly-typed entity id's.
- This package uses source generators to generate all the necessary code for the entity id.

```csharp
[EntityKey(Prefix = "xyz_")]
public readonly partial record struct MyAggregateRootId;

public class MyAggregateRoot : AggregateRoot<MyAggregateRootId>;
```

### NPM Packages for JavaScript/TypeScript/Node Development
> coming soon

[1]: https://en.wikipedia.org/wiki/George_Clinton_(funk_musician) "George Clinton"
