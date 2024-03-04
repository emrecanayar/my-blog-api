using Core.Application.Dtos;

namespace Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetList;

public class GetListHeadArticleFeatureUploadedFileListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid HeadArticleFeatureId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}