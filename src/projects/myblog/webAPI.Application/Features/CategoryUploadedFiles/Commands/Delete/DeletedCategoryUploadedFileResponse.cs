using Core.Application.Responses;

namespace Application.Features.CategoryUploadedFiles.Commands.Delete;

public class DeletedCategoryUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
}