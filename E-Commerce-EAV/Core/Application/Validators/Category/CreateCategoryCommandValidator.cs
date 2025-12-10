using ECommerceEAV.Application.Features.Categories.Commands;
using FluentValidation;

namespace ECommerceEAV.Application.Validators.Category
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(200).WithMessage("Category name must not exceed 200 characters.");
        }
    }
}



