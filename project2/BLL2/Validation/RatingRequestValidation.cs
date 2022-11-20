using BLL2.DTO.Request;
using FluentValidation;

namespace BLL2.Validation;

public class RatingRequestValidation : AbstractValidator<RatingRequestDTO>
{
    public RatingRequestValidation()
    {
        RuleFor(request => request.BookId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.BookId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.BookId)} can't be null.");
        
        RuleFor(request => request.UserId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.UserId)} can't be empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.UserId)} can't be null.");

        RuleFor(request => request.Ball)
            .LessThan(100)
            .WithMessage(request => $"{nameof(request.Ball)} should by less than 100");
    }
}