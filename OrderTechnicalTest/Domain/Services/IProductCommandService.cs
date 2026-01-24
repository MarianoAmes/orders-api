using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Domain.Model.Entities;

namespace OrderTechnicalTest.Domain.Services;

public interface IProductCommandService
{
    Task<IEnumerable<Product>> Handle(SeedProductsCommand command);
    
    Task<Product> Handle(CreateProductCommand command);
    Task<Product> Handle(UpdateProductCommand command);
    Task Handle(DeleteProductCommand command);
}