using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Categories.Results;
using ECommerceEAV.Application.Features.Categories.Commands;

namespace ECommerceEAV.Application.Handlers.Categories.Modify
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryCreateResult>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryCreateResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            category.CreatedDate = DateTime.UtcNow;
            category.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(category);
            return new CategoryCreateResult { Id = category.Id, Message = "Category created successfully." };
        }
    }
}
