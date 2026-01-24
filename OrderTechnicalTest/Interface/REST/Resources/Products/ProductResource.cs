namespace OrderTechnicalTest.Interface.REST.Resources;

public record ProductResource(
    Guid Id,
    string Name,
    decimal UnitPrice
);