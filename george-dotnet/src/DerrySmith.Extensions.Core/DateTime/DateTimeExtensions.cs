namespace DerrySmith.Extensions.Core.DateTime;

/// <summary>
/// 
/// </summary>
public static class DateTimeExtensions
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="dtm"></param>
	/// <returns></returns>
	public static DateTimeOffset Yesterday(this DateTimeOffset dtm) => dtm.AddDays(-1);

	/// <summary>
	/// 
	/// </summary>
	/// <param name="dtm"></param>
	/// <returns></returns>
	public static DateTimeOffset Tomorrow(this DateTimeOffset dtm) => dtm.AddDays(1);
}