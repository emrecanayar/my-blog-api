using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAboutRepository : IAsyncRepository<About, Guid>, IRepository<About, Guid>
{
}