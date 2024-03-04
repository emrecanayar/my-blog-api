using Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetById;
using Core.Application.Responses;

namespace Application.Features.HeadArticleFeatures.Queries.GetById;

public class GetByIdHeadArticleFeatureResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public IList<GetByIdHeadArticleFeatureUploadedFileResponse> HeadArticleFeatureUploadedFiles { get; set; }

    public GetByIdHeadArticleFeatureResponse()
    {
        HeadArticleFeatureUploadedFiles = [];
    }
}