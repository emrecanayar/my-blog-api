using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ContactUsInformationConfiguration : BaseConfiguration<ContactUsInformation, Guid>
{
    public override void Configure(EntityTypeBuilder<ContactUsInformation> builder)
    {
        base.Configure(builder);
        builder.Property(cui => cui.Description).HasColumnName("Description").HasMaxLength(300);
        builder.Property(cui => cui.AddressText).HasColumnName("AddressText").HasMaxLength(100);
        builder.Property(cui => cui.Email).HasColumnName("Email").HasMaxLength(50);
        builder.Property(cui => cui.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
        builder.Property(cui => cui.GithubLink).HasColumnName("GithubLink").HasMaxLength(50);
        builder.Property(cui => cui.LinkedInLink).HasColumnName("LinkedInLink").HasMaxLength(50);
        builder.Property(cui => cui.TwitterLink).HasColumnName("TwitterLink").HasMaxLength(50);
        builder.Property(cui => cui.WhatsAppLink).HasColumnName("WhatsAppLink").HasMaxLength(50);
        builder.ToTable(TableNameConstants.CONTACT_US_INFORMATION);
    }
}