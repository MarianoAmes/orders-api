using Microsoft.EntityFrameworkCore;
using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Domain.Services;

namespace OrderTechnicalTest.Application.Internal;

public class OrderCommandService(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task<Order> Handle(CreateOrderCommand command)
    {
        var order = new Order(command.OrderNumber);

        await orderRepository.AddAsync(order);

        await unitOfWork.CompleteAsync();

        return order;
    }

    public async Task<Order> Handle(UpdateOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId)
                    ?? throw new InvalidOperationException("Order not found");

        if (string.IsNullOrWhiteSpace(command.OrderNumber))
            throw new InvalidOperationException("Order number is required");

        order.GetType()
            .GetProperty(nameof(Order.OrderNumber))!
            .SetValue(order, command.OrderNumber);

        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();

        return order;
    }


    public async Task<Order> Handle(DeleteOrderCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId)
                    ?? throw new InvalidOperationException("Order not found");

        orderRepository.Remove(order);
        await unitOfWork.CompleteAsync();

        return order;
    }


    public async Task<Order> Handle(ChangeOrderStatusCommand command)
    {
        var order = await orderRepository.FindByIdAsync(command.OrderId)
                    ?? throw new InvalidOperationException("Order not found");

        order.Status = command.NewStatus;

        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();

        return order;
    }


    public async Task<Order> Handle(AddOrderItemCommand command)
    {
        var order = await unitOfWork.Context.Orders
                        .FirstOrDefaultAsync(o => o.Id == command.OrderId)
                    ?? throw new InvalidOperationException("Order not found");

        var product = await productRepository.FindByIdAsync(command.ProductId)
                      ?? throw new InvalidOperationException("Product not found");

        var orderItem = new OrderItem(
            order,
            product.Id,
            product.Name,
            product.UnitPrice,
            command.Quantity
        );

        unitOfWork.Context.OrderItems.Add(orderItem);

        await unitOfWork.CompleteAsync();

        return order;
    }


    public async Task Handle(RemoveOrderItemCommand command)
    {
        var orderItem = await unitOfWork.Context.OrderItems
                            .FirstOrDefaultAsync(i =>
                                i.Id == command.OrderItemId &&
                                i.OrderId == command.OrderId)
                        ?? throw new InvalidOperationException("Order item not found");

        unitOfWork.Context.OrderItems.Remove(orderItem);

        await unitOfWork.CompleteAsync();
    }


    public async Task<Order> Handle(UpdateOrderItemCommand command)
    {
        var orderItem = await unitOfWork.Context.OrderItems
                            .FirstOrDefaultAsync(i =>
                                i.Id == command.OrderItemId &&
                                i.OrderId == command.OrderId)
                        ?? throw new InvalidOperationException("Order item not found");
        
        if (command.Quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero");

        orderItem.Quantity = command.Quantity;

        await unitOfWork.CompleteAsync();
        
        var order = await unitOfWork.Context.Orders
            .FirstAsync(o => o.Id == command.OrderId);

        return order;
    }


}
