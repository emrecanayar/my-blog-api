using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFooterRepository : IAsyncRepository<Footer, Guid>, IRepository<Footer, Guid>
{
}