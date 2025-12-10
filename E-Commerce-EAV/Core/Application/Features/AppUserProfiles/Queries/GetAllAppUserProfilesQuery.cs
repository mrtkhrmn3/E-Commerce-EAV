using MediatR;
using ECommerceEAV.Application.Features.AppUserProfiles.Results;

namespace ECommerceEAV.Application.Features.AppUserProfiles.Queries
{
    public class GetAllAppUserProfilesQuery : IRequest<AppUserProfileListResult>
    {
    }
}

