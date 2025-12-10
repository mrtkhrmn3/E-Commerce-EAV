using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Features.Orders.Results
{
    public class OrderListResult
    {
        public List<OrderDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}







