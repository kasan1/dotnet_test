using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Primitives;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Configurations.Identity
{
    public class AgreementConfiguration : BaseEntityConfigurations<Agreement>
    {
        public override void Configure(EntityTypeBuilder<Agreement> builder)
        {
            base.Configure(builder);

            var converter = new EnumToNumberConverter<AgreementTypeEnum, int>();
            builder.Property(e => e.AgreementType)
                .HasConversion(converter)
                .IsRequired();
        }
    }
}
