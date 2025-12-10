using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.AppUserProfiles.Commands;

namespace ECommerceEAV.Application.Handlers.AppUserProfiles.Modify
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand, CommandResult>
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _repository.GetByIdAsync(request.Id);

            if (appUserProfile == null)
            {
                return new CommandResult { Success = false, Message = $"AppUserProfile ({request.Id}) was not found." };
            }

            _mapper.Map(request, appUserProfile);
            appUserProfile.UpdatedDate = DateTime.UtcNow;
            appUserProfile.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(appUserProfile);
            return new CommandResult { Success = true, Message = "App user profile updated successfully." };
        }
    }
}

