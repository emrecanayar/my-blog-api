using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICommentRepository : IAsyncRepository<Comment, Guid>, IRepository<Comment, Guid>
{
}