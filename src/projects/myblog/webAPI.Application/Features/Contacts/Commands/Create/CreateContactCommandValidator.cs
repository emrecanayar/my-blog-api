using FluentValidation;

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(c => c.FullName).NotEmpty().WithMessage("Ad Soyad alaný boþ olamaz.")
                                .MaximumLength(50).WithMessage("Ad Soyad alaný maksiumum 50 karakter olmalýdýr.");

        RuleFor(c => c.Email).NotEmpty().WithMessage("E-posta alaný boþ olamaz")
                             .MaximumLength(50).WithMessage("E-posta alaný maksimum 50 karakter olmalýdýr.")
                             .EmailAddress().WithMessage("E-posta formatý hatalýdýr.");

        RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Telefon numarasý alaný boþ olamaz.")
                                   .MaximumLength(15).WithMessage("Telefon numarasý maksimum 15 karakter olmalýdýr.")
                                   .Matches(@"^\+?[0-9]{1,15}$").WithMessage("Telefon numarasý sadece sayýsal karakterler içermelidir.");

        RuleFor(c => c.Message).NotEmpty().WithMessage("Mesaj alaný boþ olamaz.")
                               .MaximumLength(500).WithMessage("Mesaj alaný maksimum 500 karakter olmalýdýr.");
    }
}