using ECommerceEAV.Application.DTOs;

namespace ECommerceEAV.Application.Features.Users.Results
{
    public class UserListResult
    {
        public List<UserDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}







