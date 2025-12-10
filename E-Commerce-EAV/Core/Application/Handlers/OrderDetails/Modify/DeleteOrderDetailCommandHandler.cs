using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.OrderDetails.Commands;

namespace ECommerceEAV.Application.Handlers.OrderDetails.Modify
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, CommandResult>
    {
        private readonly IOrderDetailRepository _repository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.Id);

            if (orderDetail == null)
            {
                return new CommandResult { Success = false, Message = $"OrderDetail ({request.Id}) was not found." };
            }

            orderDetail.DeletedDate = DateTime.UtcNow;
            orderDetail.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(orderDetail);
            return new CommandResult { Success = true, Message = "Order detail deleted successfully." };
        }
    }
}

