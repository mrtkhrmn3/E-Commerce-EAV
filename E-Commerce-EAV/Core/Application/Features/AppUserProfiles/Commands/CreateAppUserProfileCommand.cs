using MediatR;
using ECommerceEAV.Application.Features.AppUserProfiles.Results;

namespace ECommerceEAV.Application.Features.AppUserProfiles.Commands
{
    public class CreateAppUserProfileCommand : IRequest<AppUserProfileCreateResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

