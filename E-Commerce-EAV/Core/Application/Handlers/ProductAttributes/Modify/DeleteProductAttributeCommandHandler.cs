using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.ProductAttributes.Commands;

namespace ECommerceEAV.Application.Handlers.ProductAttributes.Modify
{
    public class DeleteProductAttributeCommandHandler : IRequestHandler<DeleteProductAttributeCommand, CommandResult>
    {
        private readonly IProductAttributeRepository _repository;

        public DeleteProductAttributeCommandHandler(IProductAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _repository.GetByIdAsync(request.Id);

            if (attribute == null)
            {
                return new CommandResult { Success = false, Message = $"ProductAttribute ({request.Id}) was not found." };
            }

            attribute.DeletedDate = DateTime.UtcNow;
            attribute.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(attribute);
            return new CommandResult { Success = true, Message = "ProductAttribute deleted successfully." };
        }
    }
}





