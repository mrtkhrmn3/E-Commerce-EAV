using ECommerceEAV.Application.Common.DTOs;
using ECommerceEAV.Domain.Enums;

namespace ECommerceEAV.Application.DTOs
{
    public class ProductAttributeDto : BaseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public AttributeDataType DataType { get; set; }
        public bool IsRequired { get; set; }
    }
}
