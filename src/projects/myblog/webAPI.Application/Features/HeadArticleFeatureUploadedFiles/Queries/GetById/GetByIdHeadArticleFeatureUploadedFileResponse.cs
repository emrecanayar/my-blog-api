using Core.Application.Responses;

namespace Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetById;

public class GetByIdHeadArticleFeatureUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid HeadArticleFeatureId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; } = string.Empty;
    public string NewPath { get; set; } = string.Empty;
}