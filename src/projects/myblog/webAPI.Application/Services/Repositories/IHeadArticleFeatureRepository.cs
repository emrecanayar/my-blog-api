using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IHeadArticleFeatureRepository : IAsyncRepository<HeadArticleFeature, Guid>, IRepository<HeadArticleFeature, Guid>
{
}