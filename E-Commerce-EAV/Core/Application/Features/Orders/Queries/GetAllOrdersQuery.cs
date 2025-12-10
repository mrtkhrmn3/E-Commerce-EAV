using MediatR;
using ECommerceEAV.Application.Features.Orders.Results;

namespace ECommerceEAV.Application.Features.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<OrderListResult>
    {
    }
}
