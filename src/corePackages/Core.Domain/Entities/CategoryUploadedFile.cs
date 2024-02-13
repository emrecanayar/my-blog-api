using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class CategoryUploadedFile : Entity<Guid>
    {
        public Guid CategoryId { get; set; }
        public Guid UploadedFileId { get; set; }
        public string OldPath { get; set; }
        public string NewPath { get; set; }
        public virtual Category Category { get; set; }
        public virtual UploadedFile UploadedFile { get; set; }

        public CategoryUploadedFile()
        {
            OldPath = string.Empty;
            NewPath = string.Empty;
            Category = default!;
            UploadedFile = default!;

        }

        public CategoryUploadedFile(Guid categoryId, Guid uploadedFileId, string oldPath, string newPath)
        {
            CategoryId = categoryId;
            UploadedFileId = uploadedFileId;
            OldPath = oldPath;
            NewPath = newPath;
            Category = default!;
            UploadedFile = default!;
        }
    }
}
