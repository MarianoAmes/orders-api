namespace OrderTechnicalTest.Interface.REST.Resources.Orders;

public record AddOrderItemResource(
    Guid ProductId,
    int Quantity
);