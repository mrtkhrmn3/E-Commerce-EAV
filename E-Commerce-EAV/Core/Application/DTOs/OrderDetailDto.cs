using ECommerceEAV.Application.Common.DTOs;

namespace ECommerceEAV.Application.DTOs
{
    public class OrderDetailDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

