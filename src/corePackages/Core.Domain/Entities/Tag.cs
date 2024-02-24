using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Tag : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public Tag()
        {
            Article = default!;
        }

        public Tag(Guid id, string name)
        {
            Id = id;
            Name = name;
            Article = default!;
        }
    }
}
