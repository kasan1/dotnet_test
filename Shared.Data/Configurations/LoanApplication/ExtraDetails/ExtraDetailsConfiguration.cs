using Agro.Shared.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.ExtraDetails
{
    public class ExtraDetailsConfiguration : BaseEntityConfigurations<Entities.ClientExtraDetails.ExtraDetails>
    {
        public override void Configure(EntityTypeBuilder<Entities.ClientExtraDetails.ExtraDetails> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.VatCertificate)
                .WithMany()
                .HasForeignKey(x => x.VatCertificateId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
