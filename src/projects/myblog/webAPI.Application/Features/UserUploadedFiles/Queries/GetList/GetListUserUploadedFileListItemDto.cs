using Core.Application.Dtos;

namespace Application.Features.UserUploadedFiles.Queries.GetList;

public class GetListUserUploadedFileListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; } = string.Empty;
    public string NewPath { get; set; } = string.Empty;
}