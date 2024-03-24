using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class LikeRepository : EfRepositoryBase<Like, Guid, BaseDbContext>, ILikeRepository
{
    public LikeRepository(BaseDbContext context) : base(context)
    {
    }
    public async Task<int> CountDislikeAsync(Guid commentId)
    {
        return await Context.Set<Like>().Where(l => l.CommentId == commentId && !l.IsLiked)
                             .CountAsync();
    }

    public async Task<int> CountLikeAsync(Guid commentId)
    {
        return await Context.Set<Like>().Where(l => l.CommentId == commentId && l.IsLiked)
                              .CountAsync();
    }
}