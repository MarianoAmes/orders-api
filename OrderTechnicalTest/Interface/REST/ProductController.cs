using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderTechnicalTest.Domain.Model.Queries;
using OrderTechnicalTest.Domain.Services;
using OrderTechnicalTest.Interface.REST.Resources;
using OrderTechnicalTest.Interface.REST.Transform;

namespace OrderTechnicalTest.Interface.REST;

[ApiController]
[Route("api/v1/products")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductController(IProductCommandService productCommandService, IProductQueryService productQueryService) : ControllerBase
{
    // GET: api/v1/products
    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var result = await productQueryService
            .Handle(new GetProductsQuery());

        var resources =
            ProductResourceListFromEntityAssembler
                .ToResourceListFromEntityList(result);

        return Ok(resources);
    }
    
    // GET: api/v1/products/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id)
    {
        var product = await productQueryService
            .Handle(new GetProductsByIdQuery(id));

        if (product is null)
            return NotFound();

        var resource =
            ProductResourceFromEntityAssembler
                .ToResourceFromEntity(product);

        return Ok(resource);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(
        [FromBody] CreateProductResource resource)
    {
        var command =
            CreateProductCommandFromResourceAssembler
                .ToCommandFromResource(resource);

        var result = await productCommandService.Handle(command);

        var productResource =
            ProductResourceFromEntityAssembler
                .ToResourceFromEntity(result);

        return StatusCode(201, productResource);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProductAsync(
        Guid id,
        [FromBody] UpdateProductResource resource)
    {
        var command =
            UpdateProductCommandFromResourceAssembler
                .ToCommandFromResource(id, resource);

        var result = await productCommandService.Handle(command);

        var productResource =
            ProductResourceFromEntityAssembler
                .ToResourceFromEntity(result);

        return Ok(productResource);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProductAsync(Guid id)
    {
        var resource = new DeleteProductResource(id);
        var command =
            DeleteProductCommandFromResourceAssembler
                .ToCommandFromResource(resource);

        await productCommandService.Handle(command);

        return Ok("Product deleted");
    }
}