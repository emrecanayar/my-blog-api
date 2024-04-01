using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ArticleVote : Entity<Guid>
    {
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public VoteType Vote { get; set; }

        public ArticleVote()
        {
            Article = default!;
            User = default!;
        }

        public ArticleVote(Guid id, Guid articleId, Guid userId, VoteType vote)
        {
            ArticleId = id;
            ArticleId = articleId;
            UserId = userId;
            Vote = vote;
            Article = default!;
            User = default!;
        }
    }
}
