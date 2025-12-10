using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.ProductAttributeValues.Commands;

namespace ECommerceEAV.Application.Handlers.ProductAttributeValues.Modify
{
    public class UpdateProductAttributeValueCommandHandler : IRequestHandler<UpdateProductAttributeValueCommand, CommandResult>
    {
        private readonly IProductAttributeValueRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductAttributeValueCommandHandler(IProductAttributeValueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateProductAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = await _repository.GetByIdAsync(request.Id);

            if (attributeValue == null)
            {
                return new CommandResult { Success = false, Message = $"ProductAttributeValue ({request.Id}) was not found." };
            }

            _mapper.Map(request, attributeValue);
            attributeValue.UpdatedDate = DateTime.UtcNow;
            attributeValue.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(attributeValue);
            return new CommandResult { Success = true, Message = "ProductAttributeValue updated successfully." };
        }
    }
}





