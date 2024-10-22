using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Modules.Payments.Dto;
using PaymentService.Modules.Payments.Models;
using PaymentService.Modules.Payments.Ports;
using PaymentService.Modules.Payments.Validators;

namespace PaymentService.Modules.Payments.Endpoints;

public static class CreatePaymentEndpoint
{
    public static void CreatePayment(this IEndpointRouteBuilder endpointBuilder)
    {
        endpointBuilder.MapPost("/payments",
                async (
                    [FromBody] PaymentCreateDto paymentCreateDto,
                    [FromServices] IPaymentRepository paymentRepository,
                    [FromServices] IDateTimeService dateTimeService,
                    [FromServices] IMapper mapper,
                    [FromServices] PaymentCreateDtoValidator paymentCreateDtoValidator) =>
                {
                    var validationResult = await paymentCreateDtoValidator.ValidateAsync(paymentCreateDto);

                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary(),
                            statusCode: (int)HttpStatusCode.BadRequest);
                    }
                    
                    var payment = mapper.Map<Payment>(paymentCreateDto);
                    payment.Created = dateTimeService.GetDateTimeNow();
                    
                    await paymentRepository.CreateAsync(payment);
                    await paymentRepository.SaveChangesAsync();

                    return Results.Created();
                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Create payment")
            .WithOpenApi();
    }
}