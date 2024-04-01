using FluentValidation;

namespace Application.Features.ArticleVotes.Commands.Create;

public class CreateArticleVoteCommandValidator : AbstractValidator<CreateArticleVoteCommand>
{
    public CreateArticleVoteCommandValidator()
    {
        RuleFor(c => c.ArticleId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}