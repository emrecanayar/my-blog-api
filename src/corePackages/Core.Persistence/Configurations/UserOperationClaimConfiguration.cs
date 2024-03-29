﻿using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Core.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Persistence.Configurations
{
    public class UserOperationClaimConfiguration : BaseConfiguration<UserOperationClaim, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");
            builder.HasIndex(x => new { x.UserId, x.OperationClaimId }, "UK_UserOperationClaims_UserId_OperationClaimId").IsUnique();
            builder.HasOne(x => x.User).WithMany(x => x.UserOperationClaims).HasForeignKey(x => x.UserId);
            builder.ToTable(TableNameConstants.USER_OPERATION_CLAIM);

            builder.HasData(getSeeds());
        }

        private IEnumerable<UserOperationClaim> getSeeds()
        {
            List<UserOperationClaim> userOperationClaims = new();

            UserOperationClaim adminUserOperationClaim = new(id: Guid.Parse("827DE17A-7223-4246-BDA9-7F6CAAEEC155"), userId: SeedData.AdminUserId, operationClaimId: SeedData.AdminOperationClaimId, createdDate: new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), createdBy: "Admin");
            userOperationClaims.Add(adminUserOperationClaim);

            return userOperationClaims;
        }
    }
}
