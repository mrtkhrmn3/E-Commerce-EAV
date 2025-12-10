namespace ECommerceEAV.Domain.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
        
        // Navigation properties
        public virtual AppUser AppUser { get; set; }
    }
}

