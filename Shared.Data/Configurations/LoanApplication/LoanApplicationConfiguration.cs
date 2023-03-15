using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication
{
    public class LoanApplicationConfiguration : BaseEntityConfigurations<Context.LoanApplication>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplication> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DicLoanProducts)
                .WithMany()
                .HasForeignKey(e => e.LoanProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DicLoanType)
                .WithMany()
                .HasForeignKey(e => e.DicLoanTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DicLoanHistoryStatus)
                .WithMany()
                .HasForeignKey(e => e.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
