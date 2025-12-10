using ECommerceEAV.Application.Common.DTOs;

namespace ECommerceEAV.Application.DTOs
{
    public class AppUserProfileDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

