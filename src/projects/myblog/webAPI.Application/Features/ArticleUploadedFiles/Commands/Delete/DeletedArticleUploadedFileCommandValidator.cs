using FluentValidation;

namespace Application.Features.ArticleUploadedFiles.Commands.Delete;

public class DeleteArticleUploadedFileCommandValidator : AbstractValidator<DeleteArticleUploadedFileCommand>
{
    public DeleteArticleUploadedFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}