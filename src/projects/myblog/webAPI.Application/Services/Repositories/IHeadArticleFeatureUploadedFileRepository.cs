using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IHeadArticleFeatureUploadedFileRepository : IAsyncRepository<HeadArticleFeatureUploadedFile, Guid>, IRepository<HeadArticleFeatureUploadedFile, Guid>
{
}