using FluentValidation;

namespace LogiCommerce.Application.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        // Title validation: Null, empty or too long
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(200).WithMessage("Title cannot be more than 200 characters.");

        // CategoryId validation: Check that the category ID is provided
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Product must have a category.");

        // Stock quantity validation: Ensure stock quantity is a valid number
        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be less than zero.");
    }
}