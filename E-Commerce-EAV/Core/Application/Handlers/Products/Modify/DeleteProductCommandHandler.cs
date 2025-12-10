using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Products.Commands;

namespace ECommerceEAV.Application.Handlers.Products.Modify
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommandResult>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return new CommandResult { Success = false, Message = $"Product ({request.Id}) was not found." };
            }

            product.DeletedDate = DateTime.UtcNow;
            product.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(product);
            return new CommandResult { Success = true, Message = "Product deleted successfully." };
        }
    }
}





