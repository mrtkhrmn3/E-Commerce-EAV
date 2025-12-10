using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Users.Commands;

namespace ECommerceEAV.Application.Handlers.User.Modify
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CommandResult>
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return new CommandResult { Success = false, Message = $"User ({request.Id}) was not found." };
            }

            _mapper.Map(request, user);
            user.UpdatedDate = DateTime.UtcNow;
            user.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(user);
            return new CommandResult { Success = true, Message = "User updated successfully." };
        }
    }
}





