using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Tests.Entities;

public class EntityKeyTests
{
	[Fact]
	public void Equals_returnsTrue_whenEntityKeyPropertiesAreTheSame()
	{
		// arrange
		var entityKey1 = EntityKeyId.Parse("key_01D7CB31YQKCJPY9FDTN2WTAFF_id");
		var entityKey2 = EntityKeyId.Parse("key_01D7CB31YQKCJPY9FDTN2WTAFF_id");

		// act
		var actual = entityKey1.Equals(entityKey2);

		// assert
		actual.ShouldBeTrue();
	}

	[Fact]
	public void Equals_returnsFalse_whenEntityKeyPropertiesAreDifferent()
	{
		// arrange
		var entityKey1 = EntityKeyId.Parse("key_01D7CB31YQKCJPY9FDTN2WTAFF_id");
		var entityKey2 = EntityKeyId.Parse("key_01ASB2XFCZJY7WHZ2FNRTMQJCT_id");

		// act
		var actual = entityKey1.Equals(entityKey2);

		// assert
		actual.ShouldBeFalse();
	}

	[Fact]
	public void ToString_formatsEntityKey()
	{
		// arrange
		var entityKey = EntityKeyId.New();

		// act
		var actual = entityKey.ToString();
		
		// assert
		actual.ShouldStartWith("key_");
		actual.ShouldEndWith("_id");
	}

	[Fact]
	public void EntityKey_shouldImplementIEntityKeyInterface()
	{
		// arrange
		var entityKey = EntityKeyId.New();
		
		// assert
		entityKey.ShouldBeAssignableTo<IEntityKey>();
	}
}