using FluentValidation;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.AuthorName).NotEmpty().WithMessage("Ýsim alaný boþ olamaz.").NotNull().WithMessage("Ýsim alaný boþ olamaz.");
        RuleFor(c => c.AuthorEmail).NotEmpty().WithMessage("E-posta alaný boþ olamaz.").NotNull().WithMessage("E-posta alaný boþ olamaz.");
        RuleFor(c => c.Content).NotEmpty().WithMessage("Yorum alaný boþ olamaz.").NotNull().WithMessage("Yorum alaný boþ olamaz.");
        RuleFor(c => c.ArticleId).NotEmpty().WithMessage("Yorum yapýlacak yazý bulunamadý.").NotNull().WithMessage("Yorum yapýlacak yazý bulunamadý.");
    }
}