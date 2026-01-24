namespace OrderTechnicalTest.Interface.REST.Resources.Orders;

public record OrderItemResource(
    Guid Id,
    Guid ProductId,
    string ProductName,
    decimal UnitPrice,
    int Quantity
);