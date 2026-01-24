using OrderTechnicalTest.Domain.Model.Enums;

namespace OrderTechnicalTest.Domain.Model.Commands;

public record ChangeOrderStatusCommand(Guid OrderId, EOrderStatus NewStatus);