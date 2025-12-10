using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
