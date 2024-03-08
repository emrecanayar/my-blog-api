using FluentValidation;

namespace Application.Features.Ratings.Commands.Update;

public class UpdateRatingCommandValidator : AbstractValidator<UpdateRatingCommand>
{
    public UpdateRatingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Score).NotEmpty();
        RuleFor(c => c.ArticleId).NotEmpty();
    }
}