using Core.Application.Dtos;

namespace Application.Features.CategoryUploadedFiles.Queries.GetList;

public class GetListCategoryUploadedFileListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}