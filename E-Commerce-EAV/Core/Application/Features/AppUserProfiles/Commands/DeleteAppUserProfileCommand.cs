using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.AppUserProfiles.Commands
{
    public class DeleteAppUserProfileCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}

