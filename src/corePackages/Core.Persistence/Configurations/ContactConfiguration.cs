using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ContactConfiguration : BaseConfiguration<Contact, Guid>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        base.Configure(builder);
        builder.Property(cu => cu.FullName).HasColumnName("FullName").HasMaxLength(50);
        builder.Property(cu => cu.Email).HasColumnName("Email").HasMaxLength(50);
        builder.Property(cu => cu.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
        builder.Property(cu => cu.Message).HasColumnName("Message").HasMaxLength(500);
        builder.ToTable(TableNameConstants.CONTACT);
    }
}