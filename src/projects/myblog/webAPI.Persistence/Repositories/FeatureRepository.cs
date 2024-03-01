using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class FeatureRepository : EfRepositoryBase<Feature, Guid, BaseDbContext>, IFeatureRepository
{
    public FeatureRepository(BaseDbContext context) : base(context)
    {
    }
}