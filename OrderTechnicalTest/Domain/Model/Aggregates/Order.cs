using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Model.Enums;
using OrderTechnicalTest.Domain.Model.Exceptions;

namespace OrderTechnicalTest.Domain.Model.Aggregates;

public class Order
{
    private Order(){}
    
    public Order(string orderNumber)
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
            throw new DomainException("Order number cannot be empty");
        
        Id = Guid.NewGuid();
        OrderNumber = orderNumber;
        Date = DateTime.UtcNow;
        Status = EOrderStatus.Pending;
    }
    
    public Guid Id { get; private set; }
    public string OrderNumber { get; private set; }
    public DateTime Date { get; private set; }
    public EOrderStatus Status { get; set; }

    public List<OrderItem> Items = new();

    public int ProductsCount => Items.Sum(i => i.Quantity);
    public decimal TotalPrice => Items.Sum(i => i.TotalPrice);
    

    
    
    
}