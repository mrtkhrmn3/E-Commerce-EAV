using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Categories.Commands;

namespace ECommerceEAV.Application.Handlers.Categories.Modify
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommandResult>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return new CommandResult { Success = false, Message = $"Category ({request.Id}) was not found." };
            }

            category.DeletedDate = DateTime.UtcNow;
            category.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(category);
            return new CommandResult { Success = true, Message = "Category deleted successfully." };
        }
    }
}
