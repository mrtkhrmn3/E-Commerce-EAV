using MediatR;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Users.Commands;

namespace ECommerceEAV.Application.Handlers.User.Modify
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, CommandResult>
    {
        private readonly IAppUserRepository _repository;

        public DeleteUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return new CommandResult { Success = false, Message = $"User ({request.Id}) was not found." };
            }

            user.DeletedDate = DateTime.UtcNow;
            user.Status = Domain.Enums.DataStatus.Deleted;

            await _repository.UpdateAsync(user);
            return new CommandResult { Success = true, Message = "User deleted successfully." };
        }
    }
}





