using FluentValidation;

namespace webAPI.Application.Features.Notifications.Commands.MarkAsRead
{
    public class MarkAsReadNotificationCommandValidator : AbstractValidator<MarkAsReadNotificationCommand>
    {
        public MarkAsReadNotificationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} alanı gereklidir.")
                .NotNull();
        }
    }
}
