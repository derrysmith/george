using DerrySmith.Extensions.Core.DateTime;

namespace DerrySmith.Extensions.Core.Tests.DateTime;

public class DateTimeExtensionsTests
{
	[Fact]
	public void Yesterday_returnsOneDayPrior()
	{
		// arrange
		var dtm = DateTimeOffset.Now;
		
		// act
		var yesterday = dtm.Yesterday();
		
		// assert
		yesterday.ShouldBe(dtm.AddDays(-1));
	}
}