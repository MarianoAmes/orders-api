using Microsoft.EntityFrameworkCore;
using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Infrastructure.EFC.Context;

namespace OrderTechnicalTest.Infrastructure.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<Order?> FindByOrderNumberAsync(string orderNumber)
    {
        return await Context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
    }

    public override async Task<Order?> FindByIdAsync(Guid id)
    {
        return await Context.Orders
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public override async Task<IEnumerable<Order>> ListAsync()
    {
        return await Context.Orders.ToListAsync();
    }
}