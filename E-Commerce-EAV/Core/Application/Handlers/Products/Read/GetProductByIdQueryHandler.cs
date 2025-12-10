using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Products.Queries;
using ECommerceEAV.Application.Features.Products.Results;

namespace ECommerceEAV.Application.Handlers.Products.Read
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return new ProductResult { Data = null, Message = $"Product ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<ProductDto>(product);
            return new ProductResult { Data = dto, Message = "Success" };
        }
    }
}





