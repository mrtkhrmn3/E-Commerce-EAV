using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.OrderDetails.Commands
{
    public class DeleteOrderDetailCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}

