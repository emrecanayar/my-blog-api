using Core.Application.Responses;

namespace Application.Features.ArticleUploadedFiles.Queries.GetById;

public class GetByIdArticleUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}