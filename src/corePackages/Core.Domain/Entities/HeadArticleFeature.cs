using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class HeadArticleFeature : Entity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<HeadArticleFeatureUploadedFile> HeadArticleFeatureUploadedFiles { get; set; }

        public HeadArticleFeature()
        {
            Category = default!;
            HeadArticleFeatureUploadedFiles = [];
        }

        public HeadArticleFeature(Guid id, string title, string content, Guid categoryId)
        {
            Id = id;
            Title = title;
            Content = content;
            CategoryId = categoryId;
            Category = default!;
            HeadArticleFeatureUploadedFiles = [];
        }
    }
}
