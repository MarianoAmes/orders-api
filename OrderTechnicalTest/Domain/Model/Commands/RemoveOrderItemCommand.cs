namespace OrderTechnicalTest.Domain.Model.Commands;

public record RemoveOrderItemCommand(Guid OrderId, Guid OrderItemId);