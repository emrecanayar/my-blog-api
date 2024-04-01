using FluentValidation;

namespace Application.Features.ArticleVotes.Commands.Update;

public class UpdateArticleVoteCommandValidator : AbstractValidator<UpdateArticleVoteCommand>
{
    public UpdateArticleVoteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ArticleId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}