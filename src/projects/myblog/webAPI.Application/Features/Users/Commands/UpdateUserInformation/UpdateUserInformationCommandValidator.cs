using FluentValidation;

namespace webAPI.Application.Features.Users.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommandValidator : AbstractValidator<UpdateUserInformationCommand>
    {
        public UpdateUserInformationCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} gerekli.");
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("{PropertyName} gerekli.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("{PropertyName} gerekli.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} gerekli.");
            RuleFor(p => p.CultureType).NotEmpty().WithMessage("{PropertyName} gerekli.");
        }
    }
}
