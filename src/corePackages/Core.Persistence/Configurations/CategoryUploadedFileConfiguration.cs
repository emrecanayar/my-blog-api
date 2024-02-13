using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CategoryUploadedFileConfiguration : BaseConfiguration<CategoryUploadedFile, Guid>
{
    public override void Configure(EntityTypeBuilder<CategoryUploadedFile> builder)
    {
        base.Configure(builder);
        builder.Property(cuf => cuf.CategoryId).IsRequired(true).HasColumnName("CategoryId").HasMaxLength(250);
        builder.Property(cuf => cuf.UploadedFileId).IsRequired(true).HasColumnName("UploadedFileId").HasMaxLength(250);
        builder.Property(cuf => cuf.OldPath).IsRequired(true).HasColumnName("OldPath").HasMaxLength(250);
        builder.Property(cuf => cuf.NewPath).IsRequired(true).HasColumnName("NewPath").HasMaxLength(250);
        builder.HasOne(cuf => cuf.Category).WithMany(c => c.CategoryUploadedFiles).HasForeignKey(cuf => cuf.CategoryId);
        builder.HasOne(cuf => cuf.UploadedFile).WithMany(c => c.CategoryUploadedFiles).HasForeignKey(cuf => cuf.UploadedFileId);
        builder.ToTable(TableNameConstants.CATEGORY_UPLOADED_FILE);

    }
}