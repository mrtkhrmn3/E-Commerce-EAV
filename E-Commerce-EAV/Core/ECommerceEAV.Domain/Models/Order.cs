using ECommerceEAV.Domain.Enums;

namespace ECommerceEAV.Domain.Models
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int AppUserId { get; set; }

        // Navigation properties
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

