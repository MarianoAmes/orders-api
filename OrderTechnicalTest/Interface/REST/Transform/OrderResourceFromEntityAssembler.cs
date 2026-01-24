using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order order)
    {
        return new OrderResource(
            order.Id,
            order.OrderNumber,
            order.Date,
            order.Status,
            order.ProductsCount,
            order.TotalPrice,
            order.Items.Select(OrderItemResourceFromEntityAssembler.ToResourceFromEntity)
        );
    }
}