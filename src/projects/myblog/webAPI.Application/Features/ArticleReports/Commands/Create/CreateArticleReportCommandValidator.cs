using FluentValidation;

namespace Application.Features.ArticleReports.Commands.Create;

public class CreateArticleReportCommandValidator : AbstractValidator<CreateArticleReportCommand>
{
    public CreateArticleReportCommandValidator()
    {
        RuleFor(c => c.ArticleId).NotEmpty();
    }
}