using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.ProductAttributes.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.ProductAttributes.Queries;

namespace ECommerceEAV.Application.Handlers.ProductAttributes.Read
{
    public class GetProductAttributeByIdQueryHandler : IRequestHandler<GetProductAttributeByIdQuery, ProductAttributeResult>
    {
        private readonly IProductAttributeRepository _repository;
        private readonly IMapper _mapper;

        public GetProductAttributeByIdQueryHandler(IProductAttributeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductAttributeResult> Handle(GetProductAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            var attribute = await _repository.GetByIdAsync(request.Id);

            if (attribute == null)
            {
                return new ProductAttributeResult { Data = null, Message = $"ProductAttribute ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<ProductAttributeDto>(attribute);
            return new ProductAttributeResult { Data = dto, Message = "Success" };
        }
    }
}





