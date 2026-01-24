using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class UpdateOrderItemCommandFromResourceAssembler
{
    public static UpdateOrderItemCommand ToCommandFromResource(
        Guid orderId,
        Guid orderItemId,
        UpdateOrderItemResource resource)
        => new(orderId, orderItemId, resource.Quantity);
}