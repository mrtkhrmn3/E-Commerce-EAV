using MediatR;
using ECommerceEAV.Application.Features.Categories.Results;

namespace ECommerceEAV.Application.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryResult>
    {
        public int Id { get; set; }
    }
}
