using Microsoft.EntityFrameworkCore;
using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Model.Queries;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Domain.Services;

namespace OrderTechnicalTest.Application.Internal;

public class OrderQueryService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderQueryService
{
    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }

    public async Task<Order?> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.OrderId);
    }
    
    public async Task<IEnumerable<OrderItem>> Handle(GetOrderItemsQuery query)
    {
        return await unitOfWork.Context.OrderItems
            .Where(i => i.OrderId == query.OrderId)
            .ToListAsync();
    }
}