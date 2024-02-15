using FluentValidation;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Ad� alan� bo� ge�ilemez").NotNull().WithMessage("Ad� alan� bo� ge�ilemez");
        RuleFor(c => c.Description).NotEmpty().WithMessage("A��klama alan� bo� ge�ilemez.").NotNull().WithMessage("A��klama alan� bo� ge�ilemez.");
        RuleFor(c => c.IsPopular).NotEmpty().WithMessage("Pop�lerlik durumu belirtilmelidir.").NotNull().WithMessage("Pop�lerlik durumu belirtilmelidir.");
    }
}