using FluentValidation;

namespace webAPI.Application.Features.Comments.Commands.CreateReply
{
    public class CreateReplyCommentCommandValidator : AbstractValidator<CreateReplyCommentCommand>
    {
        public CreateReplyCommentCommandValidator()
        {
            RuleFor(c => c.AuthorName).NotEmpty().WithMessage("İsim alanı boş olamaz.").NotNull().WithMessage("İsim alanı boş olamaz.");
            RuleFor(c => c.AuthorEmail).NotEmpty().WithMessage("E-posta alanı boş olamaz.").NotNull().WithMessage("E-posta alanı boş olamaz.");
            RuleFor(c => c.Content).NotEmpty().WithMessage("Yorum alanı boş olamaz.").NotNull().WithMessage("Yorum alanı boş olamaz.");
            RuleFor(c => c.ArticleId).NotEmpty().WithMessage("Yorum yapılacak yazı bulunamadı.").NotNull().WithMessage("Yorum yapılacak yazı bulunamadı.");
            RuleFor(c => c.UserId).NotEmpty().WithMessage("Yorum yapan kullanıcı bulunamadı").NotNull().WithMessage("Yorum yapan kullanıcı bulunamadı");
            RuleFor(c => c.ParentCommentId).NotEmpty().WithMessage("Yanıt yapılacak yorum bulunamadı.").NotNull().WithMessage("Yanıt yapılacak yorum bulunamadı.");
        }
    }
}

