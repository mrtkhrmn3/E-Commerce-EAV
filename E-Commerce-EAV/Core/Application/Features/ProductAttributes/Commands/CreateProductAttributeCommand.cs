using MediatR;
using ECommerceEAV.Domain.Enums;
using ECommerceEAV.Application.Features.ProductAttributes.Results;

namespace ECommerceEAV.Application.Features.ProductAttributes.Commands
{
    public class CreateProductAttributeCommand : IRequest<ProductAttributeCreateResult>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public AttributeDataType DataType { get; set; }
        public bool IsRequired { get; set; }
    }
}
