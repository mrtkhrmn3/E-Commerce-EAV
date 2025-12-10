using MediatR;
using ECommerceEAV.Application.Features.Users.Results;

namespace ECommerceEAV.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<UserCreateResult>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
