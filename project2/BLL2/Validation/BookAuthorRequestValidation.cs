using BLL2.DTO.Request;
using FluentValidation;

namespace BLL2.Validation;

public class BookAuthorRequestValidation : AbstractValidator<BookAuthorRequestDTO>
{
    public BookAuthorRequestValidation()
    {
        RuleFor(request => request.BookId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.BookId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.BookId)} can't be null.");
        
        RuleFor(request => request.AuthorId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.AuthorId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.AuthorId)} can't be null.");
    }
}