using Core.Application.Responses;

namespace Application.Features.CategoryUploadedFiles.Queries.GetById;

public class GetByIdCategoryUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UploadedFileId { get; set; }
    public string OldPath { get; set; }
    public string NewPath { get; set; }
}