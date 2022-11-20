using BLL2.DTO.Request;
using FluentValidation;

namespace BLL2.Validation;

public class LanguageRequestValidation : AbstractValidator<LanguageRequestDTO>
{
    public LanguageRequestValidation()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.Name)} can't by empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.Name)} can't be null.")
            .MaximumLength(100)
            .WithMessage(req => $"{nameof(req.Name)} should by less than 100 characters");
        
        RuleFor(request => request.Abbreviated)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.Abbreviated)} can't by empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.Abbreviated)} can't be null.")
            .MaximumLength(10)
            .WithMessage(req => $"{nameof(req.Abbreviated)} should by less than 100 characters");
    }
}