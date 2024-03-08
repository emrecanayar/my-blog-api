using FluentValidation;

namespace Application.Features.Ratings.Commands.Create;

public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
{
    public CreateRatingCommandValidator()
    {
        RuleFor(c => c.Score).NotEmpty().WithMessage("Puan boþ geçilemez.").NotNull().WithMessage("Puan boþ geçilemez.").InclusiveBetween(1, 5).WithMessage("Puan 1 ile 5 arasýnda olmalýdýr.");
        RuleFor(c => c.ArticleId).NotEmpty();
    }
}