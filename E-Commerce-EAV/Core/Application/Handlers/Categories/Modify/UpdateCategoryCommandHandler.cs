using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Categories.Commands;

namespace ECommerceEAV.Application.Handlers.Categories.Modify
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CommandResult>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return new CommandResult { Success = false, Message = $"Category ({request.Id}) was not found." };
            }

            _mapper.Map(request, category);
            category.UpdatedDate = DateTime.UtcNow;
            category.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(category);
            return new CommandResult { Success = true, Message = "Category updated successfully." };
        }
    }
}
