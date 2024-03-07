using Core.Application.Responses;

namespace Application.Features.UserUploadedFiles.Commands.Delete;

public class DeletedUserUploadedFileResponse : IResponse
{
    public Guid Id { get; set; }
}