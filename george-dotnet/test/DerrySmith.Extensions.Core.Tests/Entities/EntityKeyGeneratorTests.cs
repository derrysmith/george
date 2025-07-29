using DerrySmith.Extensions.Core.DateTime;
using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Tests.Entities;

public class EntityKeyGeneratorTests
{
	[Fact]
	public void EntityKeyAttribute_generatesStronglyTypedEntityKey()
	{
		// arrange
		// act
		var id = EntityKeyGenId.New();
		
		// assert
		id.ToString().ShouldStartWith("ekg_");
		id.ShouldBeAssignableTo<IEntityKey>();
	}
}

[EntityKey(Prefix = "ekg_")]
public readonly partial record struct EntityKeyGenId;