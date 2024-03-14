using FluentValidation;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
    }
}