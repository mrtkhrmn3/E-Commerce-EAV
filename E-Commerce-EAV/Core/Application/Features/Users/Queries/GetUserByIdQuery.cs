using MediatR;
using ECommerceEAV.Application.Features.Users.Results;

namespace ECommerceEAV.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserResult>
    {
        public int Id { get; set; }
    }
}
