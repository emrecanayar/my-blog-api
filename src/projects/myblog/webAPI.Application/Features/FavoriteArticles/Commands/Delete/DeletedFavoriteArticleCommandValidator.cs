using FluentValidation;

namespace Application.Features.FavoriteArticles.Commands.Delete;

public class DeleteFavoriteArticleCommandValidator : AbstractValidator<DeleteFavoriteArticleCommand>
{
    public DeleteFavoriteArticleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}