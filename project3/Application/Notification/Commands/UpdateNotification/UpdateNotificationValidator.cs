using FluentValidation;

namespace Application.Notification.Commands.UpdateNotification;

public class UpdateNotificationValidator : AbstractValidator<UpdateNotificationCommand>
{
    public UpdateNotificationValidator()
    {
        RuleFor(model => model.UpdateNotificationDto.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");

        RuleFor(model => model.UpdateNotificationDto.BookmarkId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("BookmarkId must be not null");

        RuleFor(model => model.UpdateNotificationDto.ChapterId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("ChapterId must be not null");

        RuleFor(model => model.UpdateNotificationDto.IsRead)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("IsRead must be not null");
    }
}