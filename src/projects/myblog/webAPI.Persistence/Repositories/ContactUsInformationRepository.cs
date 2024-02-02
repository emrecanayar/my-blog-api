using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ContactUsInformationRepository : EfRepositoryBase<ContactUsInformation, Guid, BaseDbContext>, IContactUsInformationRepository
{
    public ContactUsInformationRepository(BaseDbContext context) : base(context)
    {
    }
}