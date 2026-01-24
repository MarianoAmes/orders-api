using OrderTechnicalTest.Domain.Model.Enums;

namespace OrderTechnicalTest.Interface.REST.Resources.Orders;

public record OrderResource(
    Guid Id,
    string OrderNumber,
    DateTime Date,
    EOrderStatus Status,
    int ProductsCount,
    decimal TotalPrice,
    IEnumerable<OrderItemResource> Items
);