using MediatR;
using ECommerceEAV.Application.Features.Users.Results;

namespace ECommerceEAV.Application.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<UserListResult>
    {
    }
}
