﻿namespace DS.George.Extensions.Core.DateTime;

public class DateTimeService : IDateTimeService
{
	public DateTimeOffset Now    => DateTimeOffset.Now;
	public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}