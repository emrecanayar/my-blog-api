using FluentValidation;

namespace Application.Features.UserUploadedFiles.Commands.Delete;

public class DeleteUserUploadedFileCommandValidator : AbstractValidator<DeleteUserUploadedFileCommand>
{
    public DeleteUserUploadedFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}