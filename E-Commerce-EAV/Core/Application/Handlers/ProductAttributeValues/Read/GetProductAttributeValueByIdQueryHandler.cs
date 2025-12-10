using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.ProductAttributeValues.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.ProductAttributeValues.Queries;

namespace ECommerceEAV.Application.Handlers.ProductAttributeValues.Read
{
    public class GetProductAttributeValueByIdQueryHandler : IRequestHandler<GetProductAttributeValueByIdQuery, ProductAttributeValueResult>
    {
        private readonly IProductAttributeValueRepository _repository;
        private readonly IMapper _mapper;

        public GetProductAttributeValueByIdQueryHandler(IProductAttributeValueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductAttributeValueResult> Handle(GetProductAttributeValueByIdQuery request, CancellationToken cancellationToken)
        {
            var attributeValue = await _repository.GetByIdAsync(request.Id);

            if (attributeValue == null)
            {
                return new ProductAttributeValueResult { Data = null, Message = $"ProductAttributeValue ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<ProductAttributeValueDto>(attributeValue);
            return new ProductAttributeValueResult { Data = dto, Message = "Success" };
        }
    }
}





