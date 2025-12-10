using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Orders.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Orders.Queries;

namespace ECommerceEAV.Application.Handlers.Orders.Read
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrderListResult>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderListResult> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<OrderDto>>(orders);
            return new OrderListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}

