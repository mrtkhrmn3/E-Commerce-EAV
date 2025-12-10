using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
