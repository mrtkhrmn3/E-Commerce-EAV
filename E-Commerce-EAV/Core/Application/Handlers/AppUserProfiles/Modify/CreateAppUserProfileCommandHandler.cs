using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.AppUserProfiles.Commands;
using ECommerceEAV.Application.Features.AppUserProfiles.Results;

namespace ECommerceEAV.Application.Handlers.AppUserProfiles.Modify
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, AppUserProfileCreateResult>
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileCreateResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = _mapper.Map<AppUserProfile>(request);
            appUserProfile.CreatedDate = DateTime.UtcNow;
            appUserProfile.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(appUserProfile);
            return new AppUserProfileCreateResult { Id = appUserProfile.Id, Message = "App user profile created successfully." };
        }
    }
}

