using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Model.Queries;

namespace OrderTechnicalTest.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetOrdersQuery query);
    Task<Order?> Handle(GetOrderByIdQuery query);
    
    Task<IEnumerable<OrderItem>> Handle(GetOrderItemsQuery query);

}