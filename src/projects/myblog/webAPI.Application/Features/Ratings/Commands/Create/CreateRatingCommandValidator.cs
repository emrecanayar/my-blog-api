using FluentValidation;

namespace Application.Features.Ratings.Commands.Create;

public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
{
    public CreateRatingCommandValidator()
    {
        RuleFor(c => c.Score).NotEmpty().WithMessage("Puan bo� ge�ilemez.").NotNull().WithMessage("Puan bo� ge�ilemez.").InclusiveBetween(1, 5).WithMessage("Puan 1 ile 5 aras�nda olmal�d�r.");
        RuleFor(c => c.ArticleId).NotEmpty();
    }
}