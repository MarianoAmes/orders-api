using OrderTechnicalTest.Domain.Model.Commands;

namespace OrderTechnicalTest.Interface.REST.Transform;

public class RemoveOrderItemCommandFromResourceAssembler
{
    public static RemoveOrderItemCommand ToCommandFromResource(
        Guid orderId,
        Guid orderItemId)
        => new(orderId, orderItemId);
}