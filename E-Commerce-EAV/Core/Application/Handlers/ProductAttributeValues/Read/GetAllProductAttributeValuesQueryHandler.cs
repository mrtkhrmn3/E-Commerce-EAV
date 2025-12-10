using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.ProductAttributeValues.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.ProductAttributeValues.Queries;

namespace ECommerceEAV.Application.Handlers.ProductAttributeValues.Read
{
    public class GetAllProductAttributeValuesQueryHandler : IRequestHandler<GetAllProductAttributeValuesQuery, ProductAttributeValueListResult>
    {
        private readonly IProductAttributeValueRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductAttributeValuesQueryHandler(IProductAttributeValueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductAttributeValueListResult> Handle(GetAllProductAttributeValuesQuery request, CancellationToken cancellationToken)
        {
            var attributeValues = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<ProductAttributeValueDto>>(attributeValues);
            return new ProductAttributeValueListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}





