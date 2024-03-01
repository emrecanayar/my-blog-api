using FluentValidation;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AuthorName).NotEmpty();
        RuleFor(c => c.AuthorEmail).NotEmpty();
        RuleFor(c => c.AuhorWebsite).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.DatePosted).NotEmpty();
        RuleFor(c => c.SendNewPosts).NotEmpty();
        RuleFor(c => c.SendNewComments).NotEmpty();
        RuleFor(c => c.RememberMe).NotEmpty();
        RuleFor(c => c.ArticleId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}