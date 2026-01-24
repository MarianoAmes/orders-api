using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class ChangeOrderStatusCommandFromResourceAssembler
{
    public static ChangeOrderStatusCommand ToCommandFromResource(
        Guid orderId,
        ChangeOrderStatusResource resource)
        => new(orderId, resource.Status);
}