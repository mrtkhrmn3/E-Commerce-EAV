using FluentValidation;

namespace ECommerceEAV.Application.Features.ProductAttributes.Commands.Create
{
    public class CreateProductAttributeCommandValidator : AbstractValidator<CreateProductAttributeCommand>
    {
        public CreateProductAttributeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Attribute name is required.")
                .MaximumLength(200).WithMessage("Attribute name must not exceed 200 characters.");
        }
    }
}





