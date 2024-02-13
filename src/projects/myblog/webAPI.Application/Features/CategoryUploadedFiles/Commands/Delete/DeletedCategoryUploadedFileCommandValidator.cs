using FluentValidation;

namespace Application.Features.CategoryUploadedFiles.Commands.Delete;

public class DeleteCategoryUploadedFileCommandValidator : AbstractValidator<DeleteCategoryUploadedFileCommand>
{
    public DeleteCategoryUploadedFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}