using FluentValidation;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty().WithMessage("E-posta alaný boþ geçilemez").NotNull().WithMessage("E-posta alaný boþ geçilemez").EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");

    }
}