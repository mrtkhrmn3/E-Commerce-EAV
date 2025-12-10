using MediatR;
using ECommerceEAV.Application.Features.ProductAttributeValues.Results;

namespace ECommerceEAV.Application.Features.ProductAttributeValues.Commands
{
    public class CreateProductAttributeValueCommand : IRequest<ProductAttributeValueCreateResult>
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }
    }
}
