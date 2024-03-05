using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class FooterRepository : EfRepositoryBase<Footer, Guid, BaseDbContext>, IFooterRepository
{
    public FooterRepository(BaseDbContext context) : base(context)
    {
    }
}