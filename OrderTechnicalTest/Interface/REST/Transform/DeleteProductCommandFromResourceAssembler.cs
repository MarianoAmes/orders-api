using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class DeleteProductCommandFromResourceAssembler
{
    public static DeleteProductCommand ToCommandFromResource(
        DeleteProductResource resource)
        => new(resource.ProductId);
}