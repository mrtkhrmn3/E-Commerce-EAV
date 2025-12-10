using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Categories.Results;
using ECommerceEAV.Application.Features.Categories.Queries;
using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Handlers.Categories.Read
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResult>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return new CategoryResult { Data = null, Message = $"Category ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<CategoryDto>(category);
            return new CategoryResult { Data = dto, Message = "Success" };
        }
    }
}
