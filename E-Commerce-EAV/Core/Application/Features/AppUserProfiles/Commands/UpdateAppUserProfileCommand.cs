using MediatR;
using ECommerceEAV.Application.Common.Results;

namespace ECommerceEAV.Application.Features.AppUserProfiles.Commands
{
    public class UpdateAppUserProfileCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

