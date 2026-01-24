using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Model.Queries;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Domain.Services;

namespace OrderTechnicalTest.Application.Internal;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery query)
    {
        return await productRepository.ListAsync();
    }

    public async Task<Product?> Handle(GetProductsByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
}