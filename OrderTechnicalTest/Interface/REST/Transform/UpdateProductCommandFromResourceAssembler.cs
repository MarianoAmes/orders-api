using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(
        Guid productId,
        UpdateProductResource resource)
        => new(productId, resource.Name, resource.UnitPrice);
}