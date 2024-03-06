using FluentValidation;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty().WithMessage("E-posta alan� bo� ge�ilemez").NotNull().WithMessage("E-posta alan� bo� ge�ilemez").EmailAddress().WithMessage("Ge�erli bir e-posta adresi giriniz");

    }
}