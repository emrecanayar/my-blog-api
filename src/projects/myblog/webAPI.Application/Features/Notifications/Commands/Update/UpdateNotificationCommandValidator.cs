using FluentValidation;

namespace Application.Features.Notifications.Commands.Update;

public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
{
    public UpdateNotificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.IsRead).NotEmpty();
    }
}