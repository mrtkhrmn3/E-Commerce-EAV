using ECommerceEAV.Domain.Enums;

namespace ECommerceEAV.Domain.Models
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public AttributeDataType DataType { get; set; }
        public bool IsRequired { get; set; }
        
        // Navigation properties
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}

