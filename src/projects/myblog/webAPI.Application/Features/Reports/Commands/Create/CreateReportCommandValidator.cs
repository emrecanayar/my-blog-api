using FluentValidation;

namespace Application.Features.Reports.Commands.Create;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        RuleFor(c => c.Reason).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DateReported).NotEmpty();
        RuleFor(c => c.CommentId).NotEmpty();
    }
}