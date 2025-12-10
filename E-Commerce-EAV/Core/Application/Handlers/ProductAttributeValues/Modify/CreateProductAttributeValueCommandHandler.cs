using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.ProductAttributeValues.Results;
using ECommerceEAV.Application.Features.ProductAttributeValues.Commands;

namespace ECommerceEAV.Application.Handlers.ProductAttributeValues.Modify
{
    public class CreateProductAttributeValueCommandHandler : IRequestHandler<CreateProductAttributeValueCommand, ProductAttributeValueCreateResult>
    {
        private readonly IProductAttributeValueRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductAttributeValueCommandHandler(IProductAttributeValueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductAttributeValueCreateResult> Handle(CreateProductAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = _mapper.Map<ProductAttributeValue>(request);
            attributeValue.CreatedDate = DateTime.UtcNow;
            attributeValue.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(attributeValue);
            return new ProductAttributeValueCreateResult { Id = attributeValue.Id, Message = "ProductAttributeValue created successfully." };
        }
    }
}





