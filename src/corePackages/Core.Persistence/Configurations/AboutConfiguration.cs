using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class AboutConfiguration : BaseConfiguration<About, Guid>
{
    public override void Configure(EntityTypeBuilder<About> builder)
    {
        base.Configure(builder);
        builder.Property(a => a.Title).HasColumnName("Title").HasMaxLength(100);
        builder.Property(a => a.Description).HasColumnName("Description").HasMaxLength(1000);
        builder.Property(a => a.Url).HasColumnName("Url").HasMaxLength(100);
        builder.HasOne(a => a.UploadedFile).WithMany(x => x.Abouts).HasForeignKey(x => x.UploadedFileId).OnDelete(DeleteBehavior.Restrict);
        builder.ToTable(TableNameConstants.ABOUT);

    }
}