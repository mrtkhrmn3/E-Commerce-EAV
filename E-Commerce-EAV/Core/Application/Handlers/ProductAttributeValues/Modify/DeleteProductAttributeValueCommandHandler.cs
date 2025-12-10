using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.ProductAttributeValues.Commands;

namespace ECommerceEAV.Application.Handlers.ProductAttributeValues.Modify
{
    public class DeleteProductAttributeValueCommandHandler : IRequestHandler<DeleteProductAttributeValueCommand, CommandResult>
    {
        private readonly IProductAttributeValueRepository _repository;

        public DeleteProductAttributeValueCommandHandler(IProductAttributeValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteProductAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = await _repository.GetByIdAsync(request.Id);

            if (attributeValue == null)
            {
                return new CommandResult { Success = false, Message = $"ProductAttributeValue ({request.Id}) was not found." };
            }

            attributeValue.DeletedDate = DateTime.UtcNow;
            attributeValue.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(attributeValue);
            return new CommandResult { Success = true, Message = "ProductAttributeValue deleted successfully." };
        }
    }
}





