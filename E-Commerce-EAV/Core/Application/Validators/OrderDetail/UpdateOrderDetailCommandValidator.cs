using FluentValidation;
using ECommerceEAV.Application.Features.OrderDetails.Commands;

namespace ECommerceEAV.Application.Validators.OrderDetail
{
    public class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("OrderDetail ID must be greater than 0.");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}

