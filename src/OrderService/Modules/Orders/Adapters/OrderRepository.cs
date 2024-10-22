using Microsoft.EntityFrameworkCore;
using OrderService.Modules.Orders.Data;
using OrderService.Modules.Orders.Models;
using OrderService.Modules.Orders.Ports;

namespace OrderService.Modules.Orders.Adapters
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDataContext _context;
        public OrderRepository(ApplicationDataContext applicationDataContext)
        {
            _context = applicationDataContext ?? throw new ArgumentNullException(nameof(applicationDataContext));
        }

        public async Task CreateAsync(Order order) => await _context.Orders.AddAsync(order);
        public async Task<IEnumerable<Order>> GetAsync() => await _context.Orders.Include(x => x.Items).ToListAsync();

        public async Task<Order?> GetAsync(Guid id) => await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 0;
        public async Task DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is not null)
            {
                _context.Remove(order);
            }
        }

    }
}
