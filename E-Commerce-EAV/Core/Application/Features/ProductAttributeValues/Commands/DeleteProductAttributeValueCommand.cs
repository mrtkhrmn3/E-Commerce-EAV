using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.ProductAttributeValues.Commands
{
    public class DeleteProductAttributeValueCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
