using ECommerceEAV.Application.Common.DTOs;

namespace ECommerceEAV.Application.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
