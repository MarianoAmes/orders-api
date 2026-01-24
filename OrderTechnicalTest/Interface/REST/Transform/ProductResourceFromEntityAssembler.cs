using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Interface.REST.Resources;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(
            entity.Id,
            entity.Name,
            entity.UnitPrice
        );
    }
}