namespace OrderTechnicalTest.Domain.Model.Commands;

public record UpdateProductCommand(Guid ProductId, string Name, decimal UnitPrice);