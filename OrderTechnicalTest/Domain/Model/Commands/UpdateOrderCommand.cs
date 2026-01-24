namespace OrderTechnicalTest.Domain.Model.Commands;

public record UpdateOrderCommand(Guid OrderId, string OrderNumber);