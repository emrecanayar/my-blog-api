using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class UserUploadedFileRepository : EfRepositoryBase<UserUploadedFile, Guid, BaseDbContext>, IUserUploadedFileRepository
{
    public UserUploadedFileRepository(BaseDbContext context) : base(context)
    {
    }
}