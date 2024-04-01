using FluentValidation;

namespace Application.Features.ArticleVotes.Commands.Delete;

public class DeleteArticleVoteCommandValidator : AbstractValidator<DeleteArticleVoteCommand>
{
    public DeleteArticleVoteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}