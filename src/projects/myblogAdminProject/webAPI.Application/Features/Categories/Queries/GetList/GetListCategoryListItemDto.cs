using Application.Features.CategoryUploadedFiles.Queries.GetList;
using Core.Application.Dtos;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
    public IList<GetListCategoryUploadedFileListItemDto> CategoryUploadedFiles { get; set; }

    public GetListCategoryListItemDto()
    {
        CategoryUploadedFiles = default!;
    }
}