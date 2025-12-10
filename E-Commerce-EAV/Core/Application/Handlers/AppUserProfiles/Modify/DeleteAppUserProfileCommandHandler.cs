using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.AppUserProfiles.Commands;

namespace ECommerceEAV.Application.Handlers.AppUserProfiles.Modify
{
    public class DeleteAppUserProfileCommandHandler : IRequestHandler<DeleteAppUserProfileCommand, CommandResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public DeleteAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _repository.GetByIdAsync(request.Id);

            if (appUserProfile == null)
            {
                return new CommandResult { Success = false, Message = $"AppUserProfile ({request.Id}) was not found." };
            }

            appUserProfile.DeletedDate = DateTime.UtcNow;
            appUserProfile.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(appUserProfile);
            return new CommandResult { Success = true, Message = "App user profile deleted successfully." };
        }
    }
}

