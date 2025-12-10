using MediatR;
using ECommerceEAV.Application.Features.Categories.Results;

namespace ECommerceEAV.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<CategoryListResult>
    {
    }
}
