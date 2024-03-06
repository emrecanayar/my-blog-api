using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class SubscriptionConfiguration : BaseConfiguration<Subscription, Guid>
{
    public override void Configure(EntityTypeBuilder<Subscription> builder)
    {
        base.Configure(builder);
        builder.Property(s => s.FirstName).IsRequired(true).HasColumnName("FirstName").HasMaxLength(250);
        builder.Property(s => s.LastName).IsRequired(true).HasColumnName("LastName").HasMaxLength(250);
        builder.Property(s => s.Email).IsRequired(true).HasColumnName("Email").HasMaxLength(250);
        builder.Property(s => s.UserId).IsRequired(false).HasColumnName("UserId").HasMaxLength(250);
        builder.HasOne(s => s.User).WithMany(u => u.Subscriptions).HasForeignKey(s => s.UserId);
        builder.ToTable(TableNameConstants.SUBSCRIPTION);

    }
}