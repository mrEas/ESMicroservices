namespace PaymentService.Modules.Payments.Dto;

public class PaymentCreateDto
{
    public Guid OrderId { get; set; }
    public decimal Price { get; set; }
}