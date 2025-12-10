namespace ECommerceEAV.Domain.Models
{
    public class ProductAttributeValue : BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }  // Özelliğin değeri
        
        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}







