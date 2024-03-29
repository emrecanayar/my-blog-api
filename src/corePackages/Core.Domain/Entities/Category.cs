﻿using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPopular { get; set; }
        public Guid UploadedFileId { get; set; }
        public UploadedFile UploadedFile { get; set; }
        public ICollection<CategoryUploadedFile> CategoryUploadedFiles { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<HeadArticleFeature> HeadArticleFeatures { get; set; }

        public Category()
        {
            UploadedFile = default!;
            CategoryUploadedFiles = new HashSet<CategoryUploadedFile>();
            Articles = new HashSet<Article>();
            HeadArticleFeatures = [];
        }

        public Category(Guid id, string name, string description, bool isPopular)
        {
            Id = id;
            Name = name;
            Description = description;
            IsPopular = isPopular;
            UploadedFile = default!;
            CategoryUploadedFiles = new HashSet<CategoryUploadedFile>();
            Articles = new HashSet<Article>();
            HeadArticleFeatures = [];
        }
    }
}
