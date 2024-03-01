using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Feature : Entity<Guid>
    {
        public string Title { get; set; } = string.Empty;

    }
}
