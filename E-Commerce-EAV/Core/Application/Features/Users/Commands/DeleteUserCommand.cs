using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.Users.Commands
{
    public class DeleteUserCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
