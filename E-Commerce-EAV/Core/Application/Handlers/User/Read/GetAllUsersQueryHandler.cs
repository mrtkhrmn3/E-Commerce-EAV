using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Users.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Users.Queries;

namespace ECommerceEAV.Application.Handlers.User.Read
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UserListResult>
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserListResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<UserDto>>(users);
            return new UserListResult { Data = dtos, TotalCount = dtos.Count };
        }
    }
}





