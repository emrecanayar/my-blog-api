using Core.Application.Responses;

namespace Application.Features.ArticleUploadedFiles.Commands.Delete;

public class DeletedArticleUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
}