using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICategoryUploadedFileRepository : IAsyncRepository<CategoryUploadedFile, Guid>, IRepository<CategoryUploadedFile, Guid>
{
}