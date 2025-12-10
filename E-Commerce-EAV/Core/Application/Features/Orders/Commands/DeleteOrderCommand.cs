using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
