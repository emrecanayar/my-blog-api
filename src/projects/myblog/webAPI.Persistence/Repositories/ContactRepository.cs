using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ContactRepository : EfRepositoryBase<Contact, Guid, BaseDbContext>, IContactRepository
{
    public ContactRepository(BaseDbContext context) : base(context)
    {
    }
}