using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Categories.Results;
using ECommerceEAV.Application.Features.Categories.Queries;
using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Handlers.Categories.Read
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryListResult>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListResult> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<CategoryDto>>(categories);
            return new CategoryListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}
