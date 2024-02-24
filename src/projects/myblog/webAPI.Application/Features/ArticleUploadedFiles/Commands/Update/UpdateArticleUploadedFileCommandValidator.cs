using FluentValidation;

namespace Application.Features.ArticleUploadedFiles.Commands.Update;

public class UpdateArticleUploadedFileCommandValidator : AbstractValidator<UpdateArticleUploadedFileCommand>
{
    public UpdateArticleUploadedFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ArticleId).NotEmpty();
        RuleFor(c => c.UploadedFileId).NotEmpty();
        RuleFor(c => c.OldPath).NotEmpty();
        RuleFor(c => c.NewPath).NotEmpty();
    }
}