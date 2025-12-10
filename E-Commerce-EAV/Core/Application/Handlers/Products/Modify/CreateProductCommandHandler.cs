using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Products.Commands;
using ECommerceEAV.Application.Features.Products.Results;

namespace ECommerceEAV.Application.Handlers.Products.Modify
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductCreateResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCreateResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.CreatedDate = DateTime.UtcNow;
            product.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(product);
            return new ProductCreateResult { Id = product.Id, Message = "Product created successfully." };
        }
    }
}





