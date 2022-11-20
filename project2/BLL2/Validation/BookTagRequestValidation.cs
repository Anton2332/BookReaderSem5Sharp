using BLL2.DTO.Request;
using FluentValidation;

namespace BLL2.Validation;

public class BookTagRequestValidation : AbstractValidator<BookTagRequestDTO>
{
    public BookTagRequestValidation()
    {
        RuleFor(request => request.BookId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.BookId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.BookId)} can't be null.");
        
        RuleFor(request => request.TagId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.TagId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.TagId)} can't be null.");
    }
}