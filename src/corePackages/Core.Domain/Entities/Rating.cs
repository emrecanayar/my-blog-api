using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Rating : Entity<Guid>
    {
        public int Score { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public Rating()
        {
            User = default!;
            Article = default!;
            Notifications = [];
        }

        public Rating(Guid id, int score, Guid userId, Guid articleId)
        {
            Id = id;
            Score = score;
            UserId = userId;
            ArticleId = articleId;
            User = default!;
            Article = default!;
            Notifications = [];
        }
    }
}
