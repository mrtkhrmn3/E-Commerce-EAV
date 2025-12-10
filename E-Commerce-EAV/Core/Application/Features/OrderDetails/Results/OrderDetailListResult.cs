using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Features.OrderDetails.Results
{
    public class OrderDetailListResult
    {
        public List<OrderDetailDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}

