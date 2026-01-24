using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Interface.REST.Resources;

namespace OrderTechnicalTest.Interface.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(
        CreateProductResource resource) 
        => new (resource.Name, resource.UnitPrice);
}