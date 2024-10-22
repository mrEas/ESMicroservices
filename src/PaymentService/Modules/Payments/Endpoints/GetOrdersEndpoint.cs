using AutoMapper;
using PaymentService.Modules.Payments.Dto;
using PaymentService.Modules.Payments.Ports;

namespace PaymentService.Modules.Payments.Endpoints;

public static class GetPaymentsEndpoint
{
    public static void GetPayments(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/payments", async (IPaymentRepository paymentRepository, IMapper mapper) =>
            {
                var payments = await paymentRepository.GetAsync();
                return Results.Ok(mapper.Map<IEnumerable<PaymentReadDto>>(payments));
            })
            .Produces<IEnumerable<PaymentReadDto>>(StatusCodes.Status200OK)
            .WithName("Get payments")
            .WithOpenApi()
            .CacheOutput();
    }
}