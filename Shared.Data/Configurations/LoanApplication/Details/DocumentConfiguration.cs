using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.LoanApplication.Details
{
    public class DocumentConfiguration: BaseEntityConfigurations<Document>
    {
        public override void Configure(EntityTypeBuilder<Document> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Number).HasMaxLength(100).IsRequired();
            builder.Property(e => e.DateIssue).IsRequired();
            builder.Property(e => e.Issuer).HasMaxLength(500).IsRequired();
        }
    }
}
