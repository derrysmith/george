using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.DateTime;

/// <inheritdoc />
public class DateTimeService : IDateTimeService
{
	/// <inheritdoc />
	public DateTimeOffset Now => DateTimeOffset.Now;

	/// <inheritdoc />
	public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}