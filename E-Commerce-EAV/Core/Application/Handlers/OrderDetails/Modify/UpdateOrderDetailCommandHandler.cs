using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.OrderDetails.Commands;

namespace ECommerceEAV.Application.Handlers.OrderDetails.Modify
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, CommandResult>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(
            IOrderDetailRepository orderDetailRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);

            if (orderDetail == null)
            {
                return new CommandResult { Success = false, Message = $"OrderDetail ({request.Id}) was not found." };
            }

            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
                return new CommandResult { Success = false, Message = $"Order with ID {request.OrderId} not found." };

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                return new CommandResult { Success = false, Message = $"Product with ID {request.ProductId} not found." };

            _mapper.Map(request, orderDetail);
            orderDetail.UnitPrice = product.Price;
            orderDetail.UpdatedDate = DateTime.UtcNow;
            orderDetail.Status = Domain.Enums.DataStatus.Updated;

            await _orderDetailRepository.UpdateAsync(orderDetail);
            return new CommandResult { Success = true, Message = "Order detail updated successfully." };
        }
    }
}

