using MediatR;
using ECommerceEAV.Application.Features.Products.Results;

namespace ECommerceEAV.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductCreateResult>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
