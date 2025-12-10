using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.OrderDetails.Commands;
using ECommerceEAV.Application.Features.OrderDetails.Results;

namespace ECommerceEAV.Application.Handlers.OrderDetails.Modify
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, OrderDetailCreateResult>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(
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

        public async Task<OrderDetailCreateResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
                throw new ArgumentException($"Order with ID {request.OrderId} not found.");

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new ArgumentException($"Product with ID {request.ProductId} not found.");

            var orderDetail = new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = product.Price,
                CreatedDate = DateTime.UtcNow,
                Status = Domain.Enums.DataStatus.Inserted
            };

            await _orderDetailRepository.AddAsync(orderDetail);
            return new OrderDetailCreateResult { Id = orderDetail.Id, Message = "Order detail created successfully." };
        }
    }
}

