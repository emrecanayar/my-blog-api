using FluentValidation;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Adý alaný boþ geçilemez").NotNull().WithMessage("Adý alaný boþ geçilemez");
        RuleFor(c => c.Description).NotEmpty().WithMessage("Açýklama alaný boþ geçilemez.").NotNull().WithMessage("Açýklama alaný boþ geçilemez.");
        RuleFor(c => c.IsPopular).NotEmpty().WithMessage("Popülerlik durumu belirtilmelidir.").NotNull().WithMessage("Popülerlik durumu belirtilmelidir.");
    }
}