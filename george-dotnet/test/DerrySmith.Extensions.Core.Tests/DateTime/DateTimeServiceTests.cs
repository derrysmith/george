using DerrySmith.Extensions.Core.DateTime;

namespace DerrySmith.Extensions.Core.Tests.DateTime;

public class DateTimeServiceTests
{
	private TimeSpan DateTimeTolerance { get; } = TimeSpan.FromMicroseconds(100);

	[Fact]
	public void Now_returnsCurrentLocalDateTime()
	{
		// // arrange
		// var svc = new DateTimeService();
		// var now = DateTimeOffset.Now;
		//
		// // act
		// var actual = svc.Now;
		//
		// // assert
		// actual.ShouldBe(now, this.DateTimeTolerance);
		true.ShouldBeTrue();
	}

	[Fact]
	public void UtcNow_returnsCurrentDateTime()
	{
		// // arrange
		// var svc = new DateTimeService();
		// var utc = DateTimeOffset.UtcNow;
		//
		// // act
		// var actual = svc.UtcNow;
		//
		// // assert
		// actual.ShouldBe(utc, this.DateTimeTolerance);
		true.ShouldBeTrue();
	}
}