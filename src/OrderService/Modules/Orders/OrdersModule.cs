using Microsoft.EntityFrameworkCore;
using OrderService.Modules.Common.Ports;
using OrderService.Modules.Orders.Adapters;
using OrderService.Modules.Orders.Data;
using OrderService.Modules.Orders.Endpoints;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders
{
    public class OrdersModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration, bool isProduction)
        {
            if (isProduction)
            {
                builder.AddDbContext<ApplicationDataContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("Default")));
            }
            else
            {
                builder.AddDbContext<ApplicationDataContext>(options =>
                    options.UseInMemoryDatabase("InMemory"));
            }

            builder.AddScoped<IOrderRepository, OrderRepository>();
            builder.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder edpoints)
        {
            edpoints.CreateOrder();
            edpoints.GetOrders();
            edpoints.GetOrder();
            edpoints.DeleteOrder();

            return edpoints;
        }


    }
}
