using Core.Application.Dtos;

namespace Application.Features.ArticleUploadedFiles.Queries.GetList;

public class GetListArticleUploadedFileListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; } = string.Empty;
    public string NewPath { get; set; } = string.Empty;
}