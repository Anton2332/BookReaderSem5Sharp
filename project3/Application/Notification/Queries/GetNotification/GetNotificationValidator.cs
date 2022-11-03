using FluentValidation;

namespace Application.Notification.Queries.GetNotification;

public class GetNotificationValidator : AbstractValidator<GetNotificationQuery>
{
    public GetNotificationValidator()
    {
        RuleFor(model => model.Id)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id must be not null");
    }
}