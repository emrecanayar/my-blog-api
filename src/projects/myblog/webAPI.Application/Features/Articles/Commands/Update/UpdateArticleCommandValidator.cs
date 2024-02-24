using FluentValidation;

namespace Application.Features.Articles.Commands.Update;

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.ViewCount).NotEmpty();
        RuleFor(c => c.CommentCount).NotEmpty();
        RuleFor(c => c.SeoAuthor).NotEmpty();
        RuleFor(c => c.SeoDescription).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}