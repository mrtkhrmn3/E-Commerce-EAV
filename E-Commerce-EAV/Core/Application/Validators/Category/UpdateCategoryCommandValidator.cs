using ECommerceEAV.Application.Features.Categories.Commands;
using FluentValidation;

namespace ECommerceEAV.Application.Validators.Category
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Category ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(200).WithMessage("Category name must not exceed 200 characters.");
        }
    }
}



