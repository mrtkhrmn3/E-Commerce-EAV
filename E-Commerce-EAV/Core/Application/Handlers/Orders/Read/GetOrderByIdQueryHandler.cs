using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Orders.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Orders.Queries;

namespace ECommerceEAV.Application.Handlers.Orders.Read
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResult>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);

            if (order == null)
            {
                return new OrderResult { Data = null, Message = $"Order ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<OrderDto>(order);
            return new OrderResult { Data = dto, Message = "Success" };
        }
    }
}

