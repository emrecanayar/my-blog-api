using FluentValidation;

namespace webAPI.Application.Features.FavoriteArticles.Commands.DeleteByArticleId
{
    public class DeleteFavoriteArticleByArticleIdCommandValidator : AbstractValidator<DeleteFavoriteArticleByArticleIdCommand>
    {
        public DeleteFavoriteArticleByArticleIdCommandValidator()
        {
            RuleFor(c => c.ArticleId).NotEmpty();
        }
    }
}
