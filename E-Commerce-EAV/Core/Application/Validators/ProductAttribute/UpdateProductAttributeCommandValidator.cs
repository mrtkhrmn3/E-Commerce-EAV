using FluentValidation;

namespace ECommerceEAV.Application.Features.ProductAttributes.Commands.Update
{
    public class UpdateProductAttributeCommandValidator : AbstractValidator<UpdateProductAttributeCommand>
    {
        public UpdateProductAttributeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Attribute ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Attribute name is required.")
                .MaximumLength(200).WithMessage("Attribute name must not exceed 200 characters.");
        }
    }
}





