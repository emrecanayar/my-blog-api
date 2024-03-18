using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class LikeRepository : EfRepositoryBase<Like, Guid, BaseDbContext>, ILikeRepository
{
    public LikeRepository(BaseDbContext context) : base(context)
    {
    }
}