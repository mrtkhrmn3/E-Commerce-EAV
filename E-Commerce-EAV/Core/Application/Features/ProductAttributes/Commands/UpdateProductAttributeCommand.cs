using MediatR;
using ECommerceEAV.Domain.Enums;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.ProductAttributes.Commands
{
    public class UpdateProductAttributeCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public AttributeDataType DataType { get; set; }
        public bool IsRequired { get; set; }
    }
}
