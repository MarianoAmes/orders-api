using OrderTechnicalTest.Domain.Model.Exceptions;

namespace OrderTechnicalTest.Domain.Model.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }

    private Product() { }

    public Product(string name, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Product name is required");

        if (unitPrice <= 0)
            throw new DomainException("Unit price must be greater than zero");

        Id = Guid.NewGuid();
        Name = name;
        UnitPrice = unitPrice;
    }
}