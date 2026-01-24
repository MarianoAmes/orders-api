using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Interface.REST.Resources;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class ProductResourceListFromEntityAssembler
{
    public static IEnumerable<ProductResource> ToResourceListFromEntityList(
        IEnumerable<Product> entities)
    {
        return entities.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
    }
}