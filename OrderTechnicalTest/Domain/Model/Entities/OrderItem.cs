using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Model.Exceptions;

namespace OrderTechnicalTest.Domain.Model.Entities;

public class OrderItem
{
    public Guid Id { get; private set; }

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }

    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; set; }

    public decimal TotalPrice => UnitPrice * Quantity;
    
    protected OrderItem() { }

    public OrderItem(
        Order order, 
        Guid productId,
        string productName,
        decimal unitPrice,
        int quantity)
    {
        Id = Guid.NewGuid();
        Order = order; 
        OrderId = order.Id;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}