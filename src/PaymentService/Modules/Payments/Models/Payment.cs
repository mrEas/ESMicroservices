namespace PaymentService.Modules.Payments.Models;

public class Payment
{
	public Guid Id { get; set; }
	public DateTime Created { get; set; }
	public Guid OrderId { get; set; }
	public decimal Price { get; set; }
	public PaymentStatus Status { get; set; }
}

public enum PaymentStatus
{
	Unpaid,
	Paid,
	Forbidden
}