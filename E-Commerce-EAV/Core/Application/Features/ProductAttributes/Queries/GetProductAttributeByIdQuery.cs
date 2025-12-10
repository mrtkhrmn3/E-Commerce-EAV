using MediatR;
using ECommerceEAV.Application.Features.ProductAttributes.Results;

namespace ECommerceEAV.Application.Features.ProductAttributes.Queries
{
    public class GetProductAttributeByIdQuery : IRequest<ProductAttributeResult>
    {
        public int Id { get; set; }
    }
}
