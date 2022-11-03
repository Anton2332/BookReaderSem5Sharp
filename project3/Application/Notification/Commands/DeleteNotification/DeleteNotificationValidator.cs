using FluentValidation;

namespace Application.Notification.Commands.DeleteNotification;

public class DeleteNotificationValidator : AbstractValidator<DeleteNotificationCommand>
{
    public DeleteNotificationValidator()
    {
        RuleFor(model => model.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");
    }
}