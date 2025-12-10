using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.AppUserProfiles.Queries;
using ECommerceEAV.Application.Features.AppUserProfiles.Results;

namespace ECommerceEAV.Application.Handlers.AppUserProfiles.Read
{
    public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, AppUserProfileResult>
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _repository.GetByIdAsync(request.Id);

            if (appUserProfile == null)
            {
                return new AppUserProfileResult { Data = null, Message = $"AppUserProfile ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<AppUserProfileDto>(appUserProfile);
            return new AppUserProfileResult { Data = dto, Message = "Success" };
        }
    }
}

