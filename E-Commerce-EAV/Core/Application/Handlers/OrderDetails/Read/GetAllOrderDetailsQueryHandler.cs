using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.OrderDetails.Queries;
using ECommerceEAV.Application.Features.OrderDetails.Results;

namespace ECommerceEAV.Application.Handlers.OrderDetails.Read
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, OrderDetailListResult>
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrderDetailsQueryHandler(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDetailListResult> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<OrderDetailDto>>(orderDetails);
            return new OrderDetailListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}

