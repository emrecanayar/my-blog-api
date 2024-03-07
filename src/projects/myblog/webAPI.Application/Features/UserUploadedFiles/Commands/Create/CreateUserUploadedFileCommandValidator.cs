using FluentValidation;

namespace Application.Features.UserUploadedFiles.Commands.Create;

public class CreateUserUploadedFileCommandValidator : AbstractValidator<CreateUserUploadedFileCommand>
{
    public CreateUserUploadedFileCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UploadedFileId).NotEmpty();
        RuleFor(c => c.OldPath).NotEmpty();
        RuleFor(c => c.NewPath).NotEmpty();
    }
}