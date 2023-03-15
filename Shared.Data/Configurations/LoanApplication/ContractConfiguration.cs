using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication
{
    public class ContractConfiguration : BaseEntityConfigurations<Contract>
    {
        public override void Configure(EntityTypeBuilder<Contract> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Number).HasMaxLength(100);

            builder.HasOne(e => e.DicContractStatus)
               .WithMany()
               .HasForeignKey(e => e.StatusId)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
