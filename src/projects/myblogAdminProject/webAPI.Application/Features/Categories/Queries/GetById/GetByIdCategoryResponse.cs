using Application.Features.CategoryUploadedFiles.Queries.GetList;
using Core.Application.Responses;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
    public IList<GetListCategoryUploadedFileListItemDto> CategoryUploadedFiles { get; set; }

    public GetByIdCategoryResponse()
    {
        CategoryUploadedFiles = default!;
    }
}