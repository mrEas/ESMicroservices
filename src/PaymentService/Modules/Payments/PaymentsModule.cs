using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OrderService.Modules.Common.Ports;
using PaymentService.Modules.Payments.Adapters;
using PaymentService.Modules.Payments.Data;
using PaymentService.Modules.Payments.Endpoints;
using PaymentService.Modules.Payments.Ports;

namespace PaymentService.Modules.Payments;

public class PaymentsModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration, bool isProduction)
    {
        builder.AddDbContext<ApplicationDataContext>(options => 
                options.UseInMemoryDatabase("InMemory"));    
        
        builder.AddScoped<IPaymentRepository, PaymentRepository>();
        builder.AddScoped<IDateTimeService, DateTimeService>();
        builder.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.AddValidatorsFromAssembly(typeof(PaymentsModule).Assembly);
        
        return builder;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder edpoints)
    {
        edpoints.CreatePayment();
        edpoints.GetPayments();
        edpoints.GetPayment();
        edpoints.DeletePayment();

        return edpoints;
    }
}