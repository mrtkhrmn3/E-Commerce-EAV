using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Products.Queries;
using ECommerceEAV.Application.Features.Products.Results;

namespace ECommerceEAV.Application.Handlers.Products.Read
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductListResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<ProductDto>>(products);
            return new ProductListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}





