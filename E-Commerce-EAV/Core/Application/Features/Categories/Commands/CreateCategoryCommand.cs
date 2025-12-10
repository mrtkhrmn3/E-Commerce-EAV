using MediatR;
using ECommerceEAV.Application.Features.Categories.Results;

namespace ECommerceEAV.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryCreateResult>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
