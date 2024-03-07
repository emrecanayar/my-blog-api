using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class UserUploadedFileConfiguration : BaseConfiguration<UserUploadedFile, Guid>
{
    public override void Configure(EntityTypeBuilder<UserUploadedFile> builder)
    {
        base.Configure(builder);
        builder.Property(uuf => uuf.UserId).IsRequired(true).HasColumnName("UserId");
        builder.Property(uuf => uuf.UploadedFileId).IsRequired(true).HasColumnName("UploadedFileId");
        builder.Property(uuf => uuf.OldPath).IsRequired(true).HasColumnName("OldPath").HasMaxLength(250);
        builder.Property(uuf => uuf.NewPath).IsRequired(true).HasColumnName("NewPath").HasMaxLength(250);
        builder.HasOne(uuf => uuf.User).WithMany(u => u.UserUploadedFiles).HasForeignKey(uuf => uuf.UserId);
        builder.HasOne(uuf => uuf.UploadedFile).WithMany(u => u.UserUploadedFiles).HasForeignKey(uuf => uuf.UploadedFileId);
        builder.ToTable(TableNameConstants.USER_UPLOADED_FILE);

    }
}