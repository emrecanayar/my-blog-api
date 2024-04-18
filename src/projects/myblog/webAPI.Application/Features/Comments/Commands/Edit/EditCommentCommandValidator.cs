using FluentValidation;

namespace webAPI.Application.Features.Comments.Commands.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} gerekli.")
                .NotNull();

            RuleFor(p => p.AuthorName)
                .NotEmpty().WithMessage("{PropertyName} gerekli.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} 50 karakteri geçmemelidir.");

            RuleFor(p => p.AuhorWebsite)
                .MaximumLength(100).WithMessage("{PropertyName} 100 karakteri geçmemelidir.");

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} gerekli.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} 500 karakteri geçmemelidir.");

            RuleFor(p => p.DatePosted)
                .NotEmpty().WithMessage("{PropertyName} gerekli.")
                .NotNull();
        }
    }
}
