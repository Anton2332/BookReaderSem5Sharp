using BLL2.DTO.Request;
using FluentValidation;

namespace BLL2.Validation;

public class BookCategoryRequestValidation : AbstractValidator<BookCategoryRequestDTO>
{
    public BookCategoryRequestValidation()
    {
        RuleFor(request => request.BookId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.BookId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.BookId)} can't be null.");
        
        RuleFor(request => request.CategoryId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.CategoryId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.CategoryId)} can't be null.");

    }
}