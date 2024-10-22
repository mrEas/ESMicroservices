using PaymentService.Modules.Payments.Ports;

namespace PaymentService.Modules.Payments.Endpoints;

public static class DeletePaymentEndpoint
{
    public static void DeletePayment(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapDelete("/payments/{id:guid}", async (Guid id, IPaymentRepository paymentRepository) =>
            {
                await paymentRepository.DeleteAsync(id);
                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .WithName("Delete payment by Id")
            .WithOpenApi();
    }
}