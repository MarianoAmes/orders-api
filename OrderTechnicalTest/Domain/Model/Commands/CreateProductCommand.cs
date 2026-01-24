namespace OrderTechnicalTest.Domain.Model.Commands;

public record CreateProductCommand(string Name, decimal UnitPrice);