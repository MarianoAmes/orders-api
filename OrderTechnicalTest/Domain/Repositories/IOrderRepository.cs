using OrderTechnicalTest.Domain.Model.Aggregates;

namespace OrderTechnicalTest.Domain.Repositories;


public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order?> FindByOrderNumberAsync(string orderNumber);
}