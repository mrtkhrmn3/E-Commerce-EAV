using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.ProductAttributes.Commands;

namespace ECommerceEAV.Application.Handlers.ProductAttributes.Modify
{
    public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommand, CommandResult>
    {
        private readonly IProductAttributeRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductAttributeCommandHandler(IProductAttributeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _repository.GetByIdAsync(request.Id);

            if (attribute == null)
            {
                return new CommandResult { Success = false, Message = $"ProductAttribute ({request.Id}) was not found." };
            }

            _mapper.Map(request, attribute);
            attribute.UpdatedDate = DateTime.UtcNow;
            attribute.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(attribute);
            return new CommandResult { Success = true, Message = "ProductAttribute updated successfully." };
        }
    }
}





