using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Model.Queries;

namespace OrderTechnicalTest.Domain.Services;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> Handle(GetProductsQuery query);
    Task<Product?> Handle(GetProductsByIdQuery query);
}