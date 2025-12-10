using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.OrderDetails.Queries;
using ECommerceEAV.Application.Features.OrderDetails.Results;

namespace ECommerceEAV.Application.Handlers.OrderDetails.Read
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, OrderDetailResult>
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDetailResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.Id);

            if (orderDetail == null)
            {
                return new OrderDetailResult { Data = null, Message = $"OrderDetail ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<OrderDetailDto>(orderDetail);
            return new OrderDetailResult { Data = dto, Message = "Success" };
        }
    }
}

