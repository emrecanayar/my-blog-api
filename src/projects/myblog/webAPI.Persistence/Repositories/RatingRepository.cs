using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class RatingRepository : EfRepositoryBase<Rating, Guid, BaseDbContext>, IRatingRepository
{
    public RatingRepository(BaseDbContext context) : base(context)
    {
    }
}