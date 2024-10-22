using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Modules.Orders.Dto;
using OrderService.Modules.Orders.Models;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders.Endpoints;

public static class CreateOrderEndpoint
{
    public static void CreateOrder(this IEndpointRouteBuilder endpointBuilder)
    {
        endpointBuilder.MapPost("/orders",
                async ([FromBody] OrderCreateDto orderCreateDto, IOrderRepository orderRepository, IMapper mapper) =>
                {
                    var order = mapper.Map<Order>(orderCreateDto);
                    await orderRepository.CreateAsync(order);
                    await orderRepository.SaveChangesAsync();

                    return Results.Created();
                })
            .Produces(StatusCodes.Status201Created)
            .WithName("Create order")
            .WithOpenApi();
    }
}