using Application.Features.HeadArticleFeatureUploadedFiles.Queries.GetById;
using Core.Application.Dtos;

namespace Application.Features.HeadArticleFeatures.Queries.GetList;

public class GetListHeadArticleFeatureListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public IList<GetByIdHeadArticleFeatureUploadedFileResponse> HeadArticleFeatureUploadedFiles { get; set; }

    public GetListHeadArticleFeatureListItemDto()
    {
        HeadArticleFeatureUploadedFiles = [];
    }
}