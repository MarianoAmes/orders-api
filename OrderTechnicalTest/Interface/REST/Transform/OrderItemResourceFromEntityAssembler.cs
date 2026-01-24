using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class OrderItemResourceFromEntityAssembler
{
    public static OrderItemResource ToResourceFromEntity(OrderItem entity)
    {
        return new OrderItemResource(
            entity.Id,
            entity.ProductId,
            entity.ProductName,
            entity.UnitPrice,
            entity.Quantity
        );
    }
}