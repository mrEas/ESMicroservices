using PaymentService.Modules.Payments.Models;

namespace PaymentService.Modules.Payments.Ports;

public interface IPaymentRepository
{
	Task<bool> SaveChangesAsync();
	Task<IEnumerable<Payment>> GetAsync();
	Task<Payment?> GetAsync(Guid id);
	Task CreateAsync(Payment order);
	Task DeleteAsync(Guid id);
}