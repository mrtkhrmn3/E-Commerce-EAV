using MediatR;
using ECommerceEAV.Application.Features.OrderDetails.Results;

namespace ECommerceEAV.Application.Features.OrderDetails.Commands
{
    public class CreateOrderDetailCommand : IRequest<OrderDetailCreateResult>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

