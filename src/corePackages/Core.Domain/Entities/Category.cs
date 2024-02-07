using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPopular { get; set; }
        public Guid UploadedFileId { get; set; }
        public UploadedFile UploadedFile { get; set; }

        public Category()
        {
            UploadedFile = default!;
        }

        public Category(Guid id, string name, string description, bool isPopular)
        {
            Id = id;
            Name = name;
            Description = description;
            IsPopular = isPopular;
            UploadedFile = default!;
        }
    }
}
