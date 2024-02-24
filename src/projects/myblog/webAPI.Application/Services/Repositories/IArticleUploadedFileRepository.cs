using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IArticleUploadedFileRepository : IAsyncRepository<ArticleUploadedFile, Guid>, IRepository<ArticleUploadedFile, Guid>
{
}