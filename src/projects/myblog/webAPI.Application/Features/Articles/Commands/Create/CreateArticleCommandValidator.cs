using FluentValidation;

namespace Application.Features.Articles.Commands.Create;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().WithMessage("Ba�l�k alan� bo� olamaz").NotNull().WithMessage("Ba�l�k alan� bo� olamaz");
        RuleFor(c => c.Content).NotEmpty().WithMessage("��erik alan� bo� olamaz.").NotNull().WithMessage("��erik alan� bo� olamaz.");
        RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Kategori alan� bo� olamaz.").NotNull().WithMessage("Kategori alan� bo� olamaz.");
    }
}