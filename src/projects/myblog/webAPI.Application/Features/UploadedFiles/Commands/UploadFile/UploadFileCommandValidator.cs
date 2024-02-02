using FluentValidation;

namespace webAPI.Application.Features.UploadedFiles.Commands.UploadFile
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileCommandValidator()
        {
            RuleFor(p => p.File).NotNull().WithMessage("File alanı boş geçilemez");
        }
    }
}
