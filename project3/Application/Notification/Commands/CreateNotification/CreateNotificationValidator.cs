using FluentValidation;

namespace Application.Notification.Commands.CreateNotification;

public class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationValidator()
    {

        RuleFor(model => model.CreateNotificationDto.BookmarkId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("BookmarkId must be not null");

        RuleFor(model => model.CreateNotificationDto.ChapterId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("ChapterId must be not null");
    }
}