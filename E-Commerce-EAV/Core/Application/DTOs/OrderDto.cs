using ECommerceEAV.Application.Common.DTOs;
using ECommerceEAV.Domain.Enums;

namespace ECommerceEAV.Application.DTOs
{
    public class OrderDto : BaseDto
    {
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int AppUserId { get; set; }
    }
}
