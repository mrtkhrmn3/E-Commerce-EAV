using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Features.AppUserProfiles.Results
{
    public class AppUserProfileListResult
    {
        public List<AppUserProfileDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}

