using MediatR;
using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Users.Results;
using ECommerceEAV.Application.Features.Users.Commands;

namespace ECommerceEAV.Application.Handlers.User.Modify
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCreateResult>
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserCreateResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request);
            user.CreatedDate = DateTime.UtcNow;
            user.Status = Domain.Enums.DataStatus.Inserted;

            await _repository.AddAsync(user);
            return new UserCreateResult { Id = user.Id, Message = "User created successfully." };
        }
    }
}





