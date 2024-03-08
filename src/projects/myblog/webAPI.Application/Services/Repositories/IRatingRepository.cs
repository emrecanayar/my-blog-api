using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRatingRepository : IAsyncRepository<Rating, Guid>, IRepository<Rating, Guid>
{
}