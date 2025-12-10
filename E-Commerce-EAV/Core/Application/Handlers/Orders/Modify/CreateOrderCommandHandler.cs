using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Orders.Results;
using ECommerceEAV.Application.Features.Orders.Commands;

namespace ECommerceEAV.Application.Handlers.Orders.Modify
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderCreateResult>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderCreateResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order.CreatedDate = DateTime.UtcNow;
            order.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(order);
            return new OrderCreateResult { Id = order.Id, Message = "Order created successfully." };
        }
    }
}

