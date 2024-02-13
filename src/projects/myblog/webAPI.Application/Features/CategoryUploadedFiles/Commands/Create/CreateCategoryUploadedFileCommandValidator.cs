using FluentValidation;

namespace Application.Features.CategoryUploadedFiles.Commands.Create;

public class CreateCategoryUploadedFileCommandValidator : AbstractValidator<CreateCategoryUploadedFileCommand>
{
    public CreateCategoryUploadedFileCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.UploadedFileId).NotEmpty();
        RuleFor(c => c.OldPath).NotEmpty();
        RuleFor(c => c.NewPath).NotEmpty();
    }
}