using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ArticleUploadedFile : Entity<Guid>
    {
        public Guid ArticleId { get; set; }
        public Guid UploadedFileId { get; set; }
        public string OldPath { get; set; }
        public string NewPath { get; set; }
        public virtual Article Article { get; set; }
        public virtual UploadedFile UploadedFile { get; set; }


        public ArticleUploadedFile()
        {
            OldPath = string.Empty;
            NewPath = string.Empty;
            Article = default!;
            UploadedFile = default!;
        }

        public ArticleUploadedFile(Guid articleId, Guid uploadedFileId, string oldPath, string newPath)
        {
            ArticleId = articleId;
            UploadedFileId = uploadedFileId;
            OldPath = oldPath;
            NewPath = newPath;
            Article = default!;
            UploadedFile = default!;
        }
    }
}
