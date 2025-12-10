using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Features.ProductAttributes.Results
{
    public class ProductAttributeListResult
    {
        public List<ProductAttributeDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}







