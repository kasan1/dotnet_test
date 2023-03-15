using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class PersonalityDocumentConfiguration : BaseEntityConfigurations<PersonalityDocument>
    {
        public override void Configure(EntityTypeBuilder<PersonalityDocument> builder)
        {
            base.Configure(builder);
        }
    }
}
