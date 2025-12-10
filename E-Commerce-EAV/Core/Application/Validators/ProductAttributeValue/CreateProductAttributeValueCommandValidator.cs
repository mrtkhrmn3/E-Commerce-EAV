using FluentValidation;

namespace ECommerceEAV.Application.Features.ProductAttributeValues.Commands.Create
{
    public class CreateProductAttributeValueCommandValidator : AbstractValidator<CreateProductAttributeValueCommand>
    {
        public CreateProductAttributeValueCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be greater than 0.");

            RuleFor(x => x.ProductAttributeId)
                .GreaterThan(0).WithMessage("Product Attribute ID must be greater than 0.");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Value is required.");
        }
    }
}





