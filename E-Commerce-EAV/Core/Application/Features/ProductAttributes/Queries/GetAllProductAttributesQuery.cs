using MediatR;
using ECommerceEAV.Application.Features.ProductAttributes.Results;

namespace ECommerceEAV.Application.Features.ProductAttributes.Queries
{
    public class GetAllProductAttributesQuery : IRequest<ProductAttributeListResult>
    {
    }
}
