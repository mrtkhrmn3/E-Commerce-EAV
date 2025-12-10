using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.ProductAttributes.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.ProductAttributes.Queries;

namespace ECommerceEAV.Application.Handlers.ProductAttributes.Read
{
    public class GetAllProductAttributesQueryHandler : IRequestHandler<GetAllProductAttributesQuery, ProductAttributeListResult>
    {
        private readonly IProductAttributeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductAttributesQueryHandler(IProductAttributeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductAttributeListResult> Handle(GetAllProductAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<ProductAttributeDto>>(attributes);
            return new ProductAttributeListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}





