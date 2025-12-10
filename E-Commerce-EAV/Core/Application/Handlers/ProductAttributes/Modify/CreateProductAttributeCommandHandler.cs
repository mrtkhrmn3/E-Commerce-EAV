using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.ProductAttributes.Results;
using ECommerceEAV.Application.Features.ProductAttributes.Commands;

namespace ECommerceEAV.Application.Handlers.ProductAttributes.Modify
{
    public class CreateProductAttributeCommandHandler : IRequestHandler<CreateProductAttributeCommand, ProductAttributeCreateResult>
    {
        private readonly IProductAttributeRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductAttributeCommandHandler(IProductAttributeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductAttributeCreateResult> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = _mapper.Map<ProductAttribute>(request);
            attribute.CreatedDate = DateTime.UtcNow;
            attribute.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(attribute);
            return new ProductAttributeCreateResult { Id = attribute.Id, Message = "ProductAttribute created successfully." };
        }
    }
}





