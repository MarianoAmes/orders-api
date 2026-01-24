using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Model.Commands;

namespace OrderTechnicalTest.Domain.Services;

public interface IOrderCommandService
{
    Task<Order> Handle(CreateOrderCommand command);
    Task<Order> Handle(UpdateOrderCommand command);
    Task<Order> Handle(DeleteOrderCommand command);
    Task<Order> Handle(ChangeOrderStatusCommand command);
    
    Task<Order> Handle(AddOrderItemCommand command);
    Task Handle(RemoveOrderItemCommand command);
    Task<Order> Handle(UpdateOrderItemCommand command);
}