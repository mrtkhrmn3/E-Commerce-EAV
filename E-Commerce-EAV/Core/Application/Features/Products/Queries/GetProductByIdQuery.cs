using MediatR;
using ECommerceEAV.Application.Features.Products.Results;

namespace ECommerceEAV.Application.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResult>
    {
        public int Id { get; set; }
    }
}
