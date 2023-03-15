using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Identity
{
    public class UserBranchConfiguration : BaseEntityConfigurations<UserBranch>
    {
        public override void Configure(EntityTypeBuilder<UserBranch> builder)
        {
            base.Configure(builder);
            
            builder.HasOne(x => x.User)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(x => new { x.UserId, x.BranchId, x.PositionId })
                .HasFilter("[IsDeleted] = 0 AND [PositionId] IS NOT NULL")
                .IsUnique();
        }
    }
}
