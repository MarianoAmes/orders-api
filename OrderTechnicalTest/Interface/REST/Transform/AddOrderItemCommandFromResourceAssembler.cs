using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class AddOrderItemCommandFromResourceAssembler
{
    public static AddOrderItemCommand ToCommandFromResource(
        Guid orderId,
        AddOrderItemResource resource)
        => new(orderId, resource.ProductId, resource.Quantity);
}