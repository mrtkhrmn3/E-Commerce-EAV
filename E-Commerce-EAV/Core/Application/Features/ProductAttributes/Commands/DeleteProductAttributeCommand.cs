using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.ProductAttributes.Commands
{
    public class DeleteProductAttributeCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
