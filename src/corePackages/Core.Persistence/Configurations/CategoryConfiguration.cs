using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : BaseConfiguration<Category, Guid>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(LengthContraints.NameMaxLength).IsRequired(true);
        builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(LengthContraints.DescriptionMaxLength).IsRequired(false);
        builder.Property(c => c.IsPopular).HasColumnName("IsPopular").IsRequired(true);
        builder.HasOne(c => c.UploadedFile).WithMany(c => c.Categories).HasForeignKey(x => x.UploadedFileId).OnDelete(DeleteBehavior.Restrict);
        builder.ToTable(TableNameConstants.CATEGORY);

    }
}