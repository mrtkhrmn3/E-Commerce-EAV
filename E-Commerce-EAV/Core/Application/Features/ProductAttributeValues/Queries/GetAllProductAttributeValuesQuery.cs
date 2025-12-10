using MediatR;
using ECommerceEAV.Application.Features.ProductAttributeValues.Results;

namespace ECommerceEAV.Application.Features.ProductAttributeValues.Queries
{
    public class GetAllProductAttributeValuesQuery : IRequest<ProductAttributeValueListResult>
    {
    }
}
