using FluentValidation;

namespace Application.Features.UserUploadedFiles.Commands.Update;

public class UpdateUserUploadedFileCommandValidator : AbstractValidator<UpdateUserUploadedFileCommand>
{
    public UpdateUserUploadedFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UploadedFileId).NotEmpty();
        RuleFor(c => c.OldPath).NotEmpty();
        RuleFor(c => c.NewPath).NotEmpty();
    }
}