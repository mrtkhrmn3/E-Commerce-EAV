namespace ECommerceEAV.Domain.Models
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        
        // Navigation properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

