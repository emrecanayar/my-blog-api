using FluentValidation;

namespace Application.Features.Articles.Commands.Create;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().WithMessage("Baþlýk alaný boþ olamaz").NotNull().WithMessage("Baþlýk alaný boþ olamaz");
        RuleFor(c => c.Content).NotEmpty().WithMessage("Ýçerik alaný boþ olamaz.").NotNull().WithMessage("Ýçerik alaný boþ olamaz.");
        RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Kategori alaný boþ olamaz.").NotNull().WithMessage("Kategori alaný boþ olamaz.");
    }
}