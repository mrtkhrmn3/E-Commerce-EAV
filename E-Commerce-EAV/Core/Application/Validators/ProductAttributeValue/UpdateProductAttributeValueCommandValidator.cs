using FluentValidation;

namespace ECommerceEAV.Application.Features.ProductAttributeValues.Commands.Update
{
    public class UpdateProductAttributeValueCommandValidator : AbstractValidator<UpdateProductAttributeValueCommand>
    {
        public UpdateProductAttributeValueCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Attribute Value ID must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be greater than 0.");

            RuleFor(x => x.ProductAttributeId)
                .GreaterThan(0).WithMessage("Product Attribute ID must be greater than 0.");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Value is required.");
        }
    }
}





