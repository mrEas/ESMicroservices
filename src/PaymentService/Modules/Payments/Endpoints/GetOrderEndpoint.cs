using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Modules.Payments.Dto;
using PaymentService.Modules.Payments.Ports;

namespace PaymentService.Modules.Payments.Endpoints;

public static class GetPaymentEndpoint
{
    public static void GetPayment(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/payments/{id:guid}", async (Guid id, IPaymentRepository paymentRepository, IMapper mapper) =>
            {
                var payment = await paymentRepository.GetAsync(id);
                return payment is null ? Results.NotFound() : Results.Ok(mapper.Map<PaymentReadDto>(payment));
            })
            .Produces<PaymentReadDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .WithName("Get payment by Id")
            .WithOpenApi()
            .CacheOutput();
    }
}