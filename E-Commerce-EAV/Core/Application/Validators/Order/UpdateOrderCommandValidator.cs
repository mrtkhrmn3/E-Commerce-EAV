using FluentValidation;

namespace ECommerceEAV.Application.Features.Orders.Commands.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Shipping address is required.");

            RuleFor(x => x.AppUserId)
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");
        }
    }
}





