using Core.Application.Responses;

namespace Application.Features.ArticleUploadedFiles.Commands.Create;

public class CreatedArticleUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}