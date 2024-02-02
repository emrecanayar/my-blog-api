using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class About : Entity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public Guid UploadedFileId { get; set; }
        public UploadedFile UploadedFile { get; set; }

        public About()
        {
            UploadedFile = default!;
        }


        public About(Guid id, string title, string description, string url)
        {
            Id = id;
            Title = title;
            Description = description;
            Url = url;
            UploadedFile = default!;
        }

    }
}
