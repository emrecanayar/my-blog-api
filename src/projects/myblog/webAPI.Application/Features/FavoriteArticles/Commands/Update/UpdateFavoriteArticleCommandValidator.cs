using FluentValidation;

namespace Application.Features.FavoriteArticles.Commands.Update;

public class UpdateFavoriteArticleCommandValidator : AbstractValidator<UpdateFavoriteArticleCommand>
{
    public UpdateFavoriteArticleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ArticleId).NotEmpty();
    }
}