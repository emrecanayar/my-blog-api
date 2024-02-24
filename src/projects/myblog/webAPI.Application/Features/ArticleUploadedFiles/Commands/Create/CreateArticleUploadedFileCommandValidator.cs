using FluentValidation;

namespace Application.Features.ArticleUploadedFiles.Commands.Create;

public class CreateArticleUploadedFileCommandValidator : AbstractValidator<CreateArticleUploadedFileCommand>
{
    public CreateArticleUploadedFileCommandValidator()
    {
        RuleFor(c => c.ArticleId).NotEmpty();
        RuleFor(c => c.UploadedFileId).NotEmpty();
        RuleFor(c => c.OldPath).NotEmpty();
        RuleFor(c => c.NewPath).NotEmpty();
    }
}