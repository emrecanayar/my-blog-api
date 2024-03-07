using Core.Application.Responses;

namespace Application.Features.UserUploadedFiles.Queries.GetById;

public class GetByIdUserUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}