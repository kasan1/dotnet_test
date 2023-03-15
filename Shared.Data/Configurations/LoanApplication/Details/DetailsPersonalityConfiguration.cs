using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Primitives;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class DetailsPersonalityConfiguration : BaseEntityConfigurations<Context.LoanApplications.DetailsPersonality>
    {
        public override void Configure(EntityTypeBuilder<Context.LoanApplications.DetailsPersonality> builder)
        {
            base.Configure(builder);
            var converter = new EnumToNumberConverter<PersonalityTypeEnum, int>();
            builder.Property(e => e.PersonalityType)
                .HasConversion(converter)
                .IsRequired();
        }
    }
}
