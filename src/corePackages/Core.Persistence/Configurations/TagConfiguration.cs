using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class TagConfiguration : BaseConfiguration<Tag, Guid>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        base.Configure(builder);
        builder.Property(t => t.Name).IsRequired(true).HasColumnName("Name").HasMaxLength(LengthContraints.Tag);
        builder.HasOne(t => t.Article).WithMany(a => a.Tags).HasForeignKey(t => t.ArticleId);
        builder.ToTable(TableNameConstants.TAG);

    }
}