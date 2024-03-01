using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class CommentRepository : EfRepositoryBase<Comment, Guid, BaseDbContext>, ICommentRepository
{
    public CommentRepository(BaseDbContext context) : base(context)
    {
    }
}