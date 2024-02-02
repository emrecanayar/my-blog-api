using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IContactUsInformationRepository : IAsyncRepository<ContactUsInformation, Guid>, IRepository<ContactUsInformation, Guid>
{
}