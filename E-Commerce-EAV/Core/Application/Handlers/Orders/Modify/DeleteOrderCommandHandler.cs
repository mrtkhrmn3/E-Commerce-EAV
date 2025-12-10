using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Orders.Commands;

namespace ECommerceEAV.Application.Handlers.Orders.Modify
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, CommandResult>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);

            if (order == null)
            {
                return new CommandResult { Success = false, Message = $"Order ({request.Id}) was not found." };
            }

            order.DeletedDate = DateTime.UtcNow;
            order.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(order);
            return new CommandResult { Success = true, Message = "Order deleted successfully." };
        }
    }
}

