using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class UserUploadedFile : Entity<Guid>
    {

        public Guid UserId { get; set; }
        public Guid UploadedFileId { get; set; }
        public string OldPath { get; set; } = string.Empty;
        public string NewPath { get; set; } = string.Empty;
        public virtual User User { get; set; } = default!;
        public virtual UploadedFile UploadedFile { get; set; } = default!;

        public UserUploadedFile()
        {

        }
        public UserUploadedFile(Guid id, Guid userId, Guid uploadedFileId, string oldPath, string newPath) : base()
        {
            Id = id;
            UserId = userId;
            UploadedFileId = uploadedFileId;
            OldPath = oldPath;
            NewPath = newPath;
        }
    }
}
