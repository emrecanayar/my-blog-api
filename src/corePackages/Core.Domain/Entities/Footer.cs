using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Footer : Entity<Guid>
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Footer()
        {

        }
        public Footer(Guid id, string title, string description) : base()
        {
            Id = id;
            Title = title;
            Description = description;
        }

    }
}
