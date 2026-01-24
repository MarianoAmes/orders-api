using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Domain.Services;

namespace OrderTechnicalTest.Application.Internal;

public class ProductCommandService(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
    : IProductCommandService
{
    public async Task<IEnumerable<Product>> Handle(SeedProductsCommand command)
    {
        var existing = await productRepository.ListAsync();
        var enumerable = existing.ToList();
        Console.WriteLine($"Products in DB: {enumerable.Count()}");
        if (enumerable.Any())
            return enumerable;

        var products = new List<Product>
        {
            new("Keyboard", 50),
            new("Mouse", 25),
            new("Monitor", 300)
        };

        foreach (var product in products)
            await productRepository.AddAsync(product);

        await unitOfWork.CompleteAsync();
        return products;
    }

    public async Task<Product> Handle(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.UnitPrice);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<Product> Handle(UpdateProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId)
            ?? throw new InvalidOperationException("Product not found");
        
        product.GetType().GetProperty(nameof(Product.Name))!
            .SetValue(product, command.Name);

        product.GetType().GetProperty(nameof(Product.UnitPrice))!
            .SetValue(product, command.UnitPrice);

        productRepository.Update(product);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task Handle(DeleteProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.ProductId)
            ?? throw new InvalidOperationException("Product not found");

        productRepository.Remove(product);
        await unitOfWork.CompleteAsync();
    }
}