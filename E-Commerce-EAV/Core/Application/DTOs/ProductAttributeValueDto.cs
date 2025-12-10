using ECommerceEAV.Application.Common.DTOs;

namespace ECommerceEAV.Application.DTOs
{
    public class ProductAttributeValueDto : BaseDto
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }
    }
}
