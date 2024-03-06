using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class SubscriptionRepository : EfRepositoryBase<Subscription, Guid, BaseDbContext>, ISubscriptionRepository
{
    public SubscriptionRepository(BaseDbContext context) : base(context)
    {
    }
}