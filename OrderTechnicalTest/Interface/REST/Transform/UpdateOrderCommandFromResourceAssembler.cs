using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderCommand ToCommandFromResource(
        Guid orderId,
        UpdateOrderResource resource)
        => new(orderId, resource.OrderNumber);
}