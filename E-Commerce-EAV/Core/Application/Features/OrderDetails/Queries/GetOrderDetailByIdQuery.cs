using MediatR;
using ECommerceEAV.Application.Features.OrderDetails.Results;

namespace ECommerceEAV.Application.Features.OrderDetails.Queries
{
    public class GetOrderDetailByIdQuery : IRequest<OrderDetailResult>
    {
        public int Id { get; set; }
    }
}

