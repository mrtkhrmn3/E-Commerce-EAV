using MediatR;
using ECommerceEAV.Domain.Enums;
using ECommerceEAV.Application.Features.Orders.Results;

namespace ECommerceEAV.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderCreateResult>
    {
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int AppUserId { get; set; }
    }
}
