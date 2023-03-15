using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class PhoneConfiguration : BaseEntityConfigurations<Phone>
    {
        public override void Configure(EntityTypeBuilder<Phone> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Mobile).HasMaxLength(20);
            builder.Property(e => e.Work).HasMaxLength(20);
            builder.Property(e => e.Home).HasMaxLength(20);
        }
    }
}
