using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class AboutRepository : EfRepositoryBase<About, Guid, BaseDbContext>, IAboutRepository
{
    public AboutRepository(BaseDbContext context) : base(context)
    {
    }
}