namespace OrderTechnicalTest.Domain.Model.Commands;

public record UpdateOrderItemCommand(Guid OrderId, Guid OrderItemId, int Quantity);