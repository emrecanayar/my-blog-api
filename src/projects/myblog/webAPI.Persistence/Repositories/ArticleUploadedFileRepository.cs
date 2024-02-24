using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ArticleUploadedFileRepository : EfRepositoryBase<ArticleUploadedFile, Guid, BaseDbContext>, IArticleUploadedFileRepository
{
    public ArticleUploadedFileRepository(BaseDbContext context) : base(context)
    {
    }
}