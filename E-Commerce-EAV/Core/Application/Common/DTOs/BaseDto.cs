namespace ECommerceEAV.Application.Common.DTOs
{
    public abstract class BaseDto : IDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}







