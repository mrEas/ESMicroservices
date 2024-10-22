namespace PaymentService.Modules.Payments.Dto;

public class PaymentReadDto
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public Guid OrderId { get; set; }
    public decimal Price { get; set; }
}