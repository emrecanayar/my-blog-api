using FluentValidation;

namespace Application.Features.FavoriteArticles.Commands.Create;

public class CreateFavoriteArticleCommandValidator : AbstractValidator<CreateFavoriteArticleCommand>
{
    public CreateFavoriteArticleCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ArticleId).NotEmpty();
    }
}