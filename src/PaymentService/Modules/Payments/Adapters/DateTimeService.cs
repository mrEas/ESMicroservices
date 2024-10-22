using PaymentService.Modules.Payments.Ports;

namespace PaymentService.Modules.Payments.Adapters;

public class DateTimeService : IDateTimeService
{
	public DateTime GetDateTimeNow()
	{
		return DateTime.Now;
	}
}