using FluentValidation;

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(c => c.FullName).NotEmpty().WithMessage("Ad Soyad alan� bo� olamaz.")
                                .MaximumLength(50).WithMessage("Ad Soyad alan� maksiumum 50 karakter olmal�d�r.");

        RuleFor(c => c.Email).NotEmpty().WithMessage("E-posta alan� bo� olamaz")
                             .MaximumLength(50).WithMessage("E-posta alan� maksimum 50 karakter olmal�d�r.")
                             .EmailAddress().WithMessage("E-posta format� hatal�d�r.");

        RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Telefon numaras� alan� bo� olamaz.")
                                   .MaximumLength(15).WithMessage("Telefon numaras� maksimum 15 karakter olmal�d�r.")
                                   .Matches(@"^\+?[0-9]{1,15}$").WithMessage("Telefon numaras� sadece say�sal karakterler i�ermelidir.");

        RuleFor(c => c.Message).NotEmpty().WithMessage("Mesaj alan� bo� olamaz.")
                               .MaximumLength(500).WithMessage("Mesaj alan� maksimum 500 karakter olmal�d�r.");
    }
}