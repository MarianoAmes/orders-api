namespace OrderTechnicalTest.Domain.Model.Commands;

public record AddOrderItemCommand(Guid OrderId, Guid ProductId, int Quantity);