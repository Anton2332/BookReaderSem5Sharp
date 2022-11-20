using BLL2.DTO.Request;
using FluentValidation;

namespace BLL2.Validation;

public class CategoryRequestValidation : AbstractValidator<CategoryRequestDTO>
{
    public CategoryRequestValidation()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.Name)} can't by empty.")
            .NotNull()
            .WithMessage(request => $"{nameof(request.Name)} can't be null.")
            .MaximumLength(200)
            .WithMessage(request => $"{nameof(request.Name)} should by less than 200 characters");
    }
}