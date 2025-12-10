using MediatR;
using AutoMapper;
using ECommerceEAV.Contract.RepositoryInterfaces;
using ECommerceEAV.Application.Common.Results;
using ECommerceEAV.Application.Features.Products.Commands;

namespace ECommerceEAV.Application.Handlers.Products.Modify
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommandResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return new CommandResult { Success = false, Message = $"Product ({request.Id}) was not found." };
            }

            _mapper.Map(request, product);
            product.UpdatedDate = DateTime.UtcNow;
            product.Status = Domain.Enums.DataStatus.Updated;

            await _repository.UpdateAsync(product);
            return new CommandResult { Success = true, Message = "Product updated successfully." };
        }
    }
}





