using OrderTechnicalTest.Domain.Model.Enums;

namespace OrderTechnicalTest.Interface.REST.Resources.Orders;


public record ChangeOrderStatusResource(
    EOrderStatus Status
);