using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class HeadArticleFeatureUploadedFileRepository : EfRepositoryBase<HeadArticleFeatureUploadedFile, Guid, BaseDbContext>, IHeadArticleFeatureUploadedFileRepository
{
    public HeadArticleFeatureUploadedFileRepository(BaseDbContext context) : base(context)
    {
    }
}