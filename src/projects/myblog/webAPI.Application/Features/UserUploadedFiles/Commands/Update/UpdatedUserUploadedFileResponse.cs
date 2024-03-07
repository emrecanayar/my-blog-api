using Core.Application.Responses;

namespace Application.Features.UserUploadedFiles.Commands.Update;

public class UpdatedUserUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}