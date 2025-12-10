using MediatR;
using ECommerceEAV.Application.Features.ProductAttributeValues.Results;

namespace ECommerceEAV.Application.Features.ProductAttributeValues.Queries
{
    public class GetProductAttributeValueByIdQuery : IRequest<ProductAttributeValueResult>
    {
        public int Id { get; set; }
    }
}
