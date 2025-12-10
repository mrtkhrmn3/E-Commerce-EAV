using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.AppUserProfiles.Queries;
using ECommerceEAV.Application.Features.AppUserProfiles.Results;

namespace ECommerceEAV.Application.Handlers.AppUserProfiles.Read
{
    public class GetAllAppUserProfilesQueryHandler : IRequestHandler<GetAllAppUserProfilesQuery, AppUserProfileListResult>
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAppUserProfilesQueryHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileListResult> Handle(GetAllAppUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var appUserProfiles = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<AppUserProfileDto>>(appUserProfiles);
            return new AppUserProfileListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}

