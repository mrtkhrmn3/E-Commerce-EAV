using MediatR;
using ECommerceEAV.Domain.Enums;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int AppUserId { get; set; }
    }
}
