using Microsoft.EntityFrameworkCore;
using PaymentService.Modules.Payments.Data;
using PaymentService.Modules.Payments.Models;
using PaymentService.Modules.Payments.Ports;

namespace PaymentService.Modules.Payments.Adapters;

public class PaymentRepository : IPaymentRepository
{
	private readonly ApplicationDataContext _applicationDataContext;

	public PaymentRepository(ApplicationDataContext applicationDataContext)
	{
		_applicationDataContext = applicationDataContext ?? throw new ArgumentNullException(nameof(applicationDataContext));
	}

	public async Task<bool> SaveChangesAsync() => await _applicationDataContext.SaveChangesAsync() >= 0;

	public async Task<IEnumerable<Payment>> GetAsync() => await _applicationDataContext.Payments.ToListAsync();

    public async Task<bool> IsPaymentForOrderExist(Guid orderId) => await _applicationDataContext.Payments.AnyAsync(x=>x.OrderId == orderId);

    public async Task<Payment?> GetAsync(Guid id) =>
		await _applicationDataContext.Payments.FirstOrDefaultAsync(x => x.Id == id);

	public async Task CreateAsync(Payment payment) => await _applicationDataContext.Payments.AddAsync(payment);

	public async Task DeleteAsync(Guid id)
	{
		var payment = await _applicationDataContext.Payments.FindAsync(id);

		if (payment is not null)
		{
			_applicationDataContext.Payments.Remove(payment);
		}
	}
}