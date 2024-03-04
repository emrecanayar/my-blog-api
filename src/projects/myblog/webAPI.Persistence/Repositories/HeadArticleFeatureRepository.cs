using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class HeadArticleFeatureRepository : EfRepositoryBase<HeadArticleFeature, Guid, BaseDbContext>, IHeadArticleFeatureRepository
{
    public HeadArticleFeatureRepository(BaseDbContext context) : base(context)
    {
    }
}