using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CategoryUploadedFileRepository : EfRepositoryBase<CategoryUploadedFile, Guid, BaseDbContext>, ICategoryUploadedFileRepository
{
    public CategoryUploadedFileRepository(BaseDbContext context) : base(context)
    {
    }
}