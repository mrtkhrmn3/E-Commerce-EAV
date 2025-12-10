using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Orders.Commands;

namespace ECommerceEAV.Application.Handlers.Orders.Modify
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, CommandResult>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);

            if (order == null)
            {
                return new CommandResult { Success = false, Message = $"Order ({request.Id}) was not found." };
            }

            _mapper.Map(request, order);
            order.UpdatedDate = DateTime.UtcNow;
            order.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(order);
            return new CommandResult { Success = true, Message = "Order updated successfully." };
        }
    }
}

