using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.FinAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.FinAnalysis
{
    public class SpecialRelationConfiguration : BaseCheckItemConfigurations<SpecialRelation>
    {
        #region Public functions

        public override void Configure(EntityTypeBuilder<SpecialRelation> builder)
        {
            base.Configure(builder);
        }

        #endregion

    }
}
