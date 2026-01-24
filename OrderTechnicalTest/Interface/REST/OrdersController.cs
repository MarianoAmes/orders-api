using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using OrderTechnicalTest.Domain.Model.Commands;
using OrderTechnicalTest.Domain.Model.Queries;
using OrderTechnicalTest.Domain.Services;
using OrderTechnicalTest.Interface.REST.Resources.Orders;
using OrderTechnicalTest.Interface.REST.Transform;

namespace OrderTechnicalTest.Interface.REST;

[ApiController]
[Route("api/v1/orders")]
[Produces(MediaTypeNames.Application.Json)]
public class OrdersController(
    IOrderCommandService orderCommandService,
    IOrderQueryService orderQueryService)
    : ControllerBase
{
    // CREATE ORDER
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(
        [FromBody] CreateOrderResource resource)
    {
        var command =
            CreateOrderCommandFromResourceAssembler
                .ToCommandFromResource(resource);

        var result = await orderCommandService.Handle(command);

        var orderResource =
            OrderResourceFromEntityAssembler
                .ToResourceFromEntity(result);

        return StatusCode(201, orderResource);
    }

    // GET ALL ORDERS
    [HttpGet]
    public async Task<IActionResult> GetAllOrdersAsync()
    {
        var result = await orderQueryService.Handle(new GetOrdersQuery());

        var resources = result
            .Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(resources);
    }

    // GET ORDER BY ID
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderByIdAsync(Guid id)
    {
        var order = await orderQueryService
            .Handle(new GetOrderByIdQuery(id));

        if (order is null)
            return NotFound();

        var resource =
            OrderResourceFromEntityAssembler
                .ToResourceFromEntity(order);

        return Ok(resource);
    }

    // ADD ITEM
    [HttpPost("{id:guid}/items")]
    public async Task<IActionResult> AddOrderItemAsync(
        Guid id,
        [FromBody] AddOrderItemResource resource)
    {
        var command =
            AddOrderItemCommandFromResourceAssembler
                .ToCommandFromResource(id, resource);

        var result = await orderCommandService.Handle(command);

        return Ok(
            OrderResourceFromEntityAssembler
                .ToResourceFromEntity(result));
    }

    // UPDATE ITEM
    [HttpPut("{orderId:guid}/items/{itemId:guid}")]
    public async Task<IActionResult> UpdateOrderItemAsync(
        Guid orderId,
        Guid itemId,
        [FromBody] UpdateOrderItemResource resource)
    {
        var command = new UpdateOrderItemCommand(
            orderId,
            itemId,
            resource.Quantity
        );

        var result = await orderCommandService.Handle(command);
        return Ok(result);
    }

    // DELETE ORDER
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrderAsync(Guid id)
    {
        await orderCommandService
            .Handle(new DeleteOrderCommand(id));

        return Ok("Order deleted");
    }
    
    // CHANGE ORDER STATUS
    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> ChangeOrderStatusAsync(
        Guid id,
        [FromBody] ChangeOrderStatusResource resource)
    {
        var command =
            ChangeOrderStatusCommandFromResourceAssembler
                .ToCommandFromResource(id, resource);

        var result = await orderCommandService.Handle(command);

        return Ok(
            OrderResourceFromEntityAssembler
                .ToResourceFromEntity(result));
    }
    
    // REMOVE ITEM
    [HttpDelete("{orderId:guid}/items/{itemId:guid}")]
    public async Task<IActionResult> DeleteOrderItemAsync(
        Guid orderId,
        Guid itemId)
    {
        var command = new RemoveOrderItemCommand(orderId, itemId);
        await orderCommandService.Handle(command);
        return NoContent();
    }
    
    [HttpGet("{orderId:guid}/items")]
    public async Task<IActionResult> GetOrderItemsAsync(Guid orderId)
    {
        var query = new GetOrderItemsQuery(orderId);
        var items = await orderQueryService.Handle(query);

        var resources = items
            .Select(OrderItemResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(resources);
    }


}