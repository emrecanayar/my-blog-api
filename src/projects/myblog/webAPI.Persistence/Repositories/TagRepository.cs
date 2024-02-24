using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class TagRepository : EfRepositoryBase<Tag, Guid, BaseDbContext>, ITagRepository
{
    public TagRepository(BaseDbContext context) : base(context)
    {
    }
}