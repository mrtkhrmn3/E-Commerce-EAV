namespace ECommerceEAV.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        
        // Navigation properties
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        
        // EAV için navigation property
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}


