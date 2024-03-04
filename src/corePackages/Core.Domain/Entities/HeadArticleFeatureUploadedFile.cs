using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class HeadArticleFeatureUploadedFile : Entity<Guid>
    {
        public Guid HeadArticleFeatureId { get; set; }
        public virtual HeadArticleFeature HeadArticleFeature { get; set; }
        public Guid UploadedFileId { get; set; }
        public virtual UploadedFile UploadedFile { get; set; }
        public string OldPath { get; set; } = string.Empty;
        public string NewPath { get; set; } = string.Empty;

        public HeadArticleFeatureUploadedFile()
        {
            HeadArticleFeature = default!;
            UploadedFile = default!;
        }

        public HeadArticleFeatureUploadedFile(Guid id, Guid headArticleFeatureId, Guid uploadedFileId)
        {
            Id = id;
            HeadArticleFeatureId = headArticleFeatureId;
            UploadedFileId = uploadedFileId;
            HeadArticleFeature = default!;
            UploadedFile = default!;
        }
    }
}
