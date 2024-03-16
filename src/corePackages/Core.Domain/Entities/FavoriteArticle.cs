using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class FavoriteArticle : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ArticleId { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }

        public FavoriteArticle()
        {
            User = default!;
            Article = default!;
        }

    }
}
