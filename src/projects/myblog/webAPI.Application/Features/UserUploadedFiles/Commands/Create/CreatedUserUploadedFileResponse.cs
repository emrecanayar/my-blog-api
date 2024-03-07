using Core.Application.Responses;

namespace Application.Features.UserUploadedFiles.Commands.Create;

public class CreatedUserUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; } = string.Empty;
    public string NewPath { get; set; } = string.Empty;
}