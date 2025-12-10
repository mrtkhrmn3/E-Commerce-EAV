using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Features.Users.Results;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Users.Queries;

namespace ECommerceEAV.Application.Handlers.User.Read
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResult>
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return new UserResult { Data = null, Message = $"User ({request.Id}) was not found." };
            }

            var dto = _mapper.Map<UserDto>(user);
            return new UserResult { Data = dto, Message = "Success" };
        }
    }
}





