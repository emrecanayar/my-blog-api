using FluentValidation;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.AuthorName).NotEmpty().WithMessage("�sim alan� bo� olamaz.").NotNull().WithMessage("�sim alan� bo� olamaz.");
        RuleFor(c => c.AuthorEmail).NotEmpty().WithMessage("E-posta alan� bo� olamaz.").NotNull().WithMessage("E-posta alan� bo� olamaz.");
        RuleFor(c => c.Content).NotEmpty().WithMessage("Yorum alan� bo� olamaz.").NotNull().WithMessage("Yorum alan� bo� olamaz.");
        RuleFor(c => c.SendNewPosts).NotEmpty().WithMessage("Yeni yaz�lar g�nderilsin mi?").NotNull().WithMessage("Yeni yaz�lar g�nderilsin mi?");
        RuleFor(c => c.SendNewComments).NotEmpty().WithMessage("Yeni yorumlar g�nderilsin mi?").NotNull().WithMessage("Yeni yorumlar g�nderilsin mi?");
        RuleFor(c => c.RememberMe).NotEmpty().WithMessage("Beni hat�rla");
        RuleFor(c => c.ArticleId).NotEmpty().WithMessage("Yorum yap�lacak yaz� bulunamad�.").NotNull().WithMessage("Yorum yap�lacak yaz� bulunamad�.");
    }
}