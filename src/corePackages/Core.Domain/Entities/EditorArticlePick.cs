using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class EditorArticlePick : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public EditorArticlePick()
        {
            User = default!;
            Article = default!;
        }
    }
}
