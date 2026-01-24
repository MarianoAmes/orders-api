using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources.Orders;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(
        CreateOrderResource resource)
        => new(resource.OrderNumber);
}