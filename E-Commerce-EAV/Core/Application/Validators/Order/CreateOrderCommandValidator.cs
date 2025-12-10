using FluentValidation;

namespace ECommerceEAV.Application.Features.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Shipping address is required.");

            RuleFor(x => x.AppUserId)
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");
        }
    }
}





