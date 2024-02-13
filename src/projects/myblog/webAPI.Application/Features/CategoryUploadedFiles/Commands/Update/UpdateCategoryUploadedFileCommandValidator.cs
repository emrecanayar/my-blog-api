using FluentValidation;

namespace Application.Features.CategoryUploadedFiles.Commands.Update;

public class UpdateCategoryUploadedFileCommandValidator : AbstractValidator<UpdateCategoryUploadedFileCommand>
{
    public UpdateCategoryUploadedFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.UploadedFileId).NotEmpty();
        RuleFor(c => c.OldPath).NotEmpty();
        RuleFor(c => c.NewPath).NotEmpty();
    }
}