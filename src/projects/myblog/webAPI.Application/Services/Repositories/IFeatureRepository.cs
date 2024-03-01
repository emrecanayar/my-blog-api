using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFeatureRepository : IAsyncRepository<Feature, Guid>, IRepository<Feature, Guid>
{
}