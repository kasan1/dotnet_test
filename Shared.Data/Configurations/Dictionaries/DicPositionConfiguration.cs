using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Dictionaries
{
    public class DicPositionConfiguration : BaseDictionaryConfigurations<DicPosition>
    {
        #region Public

        public override void Configure(EntityTypeBuilder<DicPosition> builder)
        {
            base.Configure(builder);

            SeedData(builder);
        }

        #endregion

        #region Private functions

        private void SeedData(EntityTypeBuilder<DicPosition> builder)
        {
            builder.HasData(new DicPosition[]
            {
                new DicPosition
                {
                    Id = Guid.Parse("68fd6f1c-1a18-4416-8e16-9ab1710fb5af"),
                    Code = "director",
                    NameRu = "Директор филиала АО «КазАгроФинанс»",
                    NameKk = "Директор филиала АО «КазАгроФинанс»"
                },
                new DicPosition
                {
                    Id = Guid.Parse("3f556caf-98be-44b3-8015-c05a9f09bf36"),
                    Code = "credit-admin",
                    NameRu = "Кредитный администратор филиала",
                    NameKk = "Кредитный администратор филиала"
                },
                new DicPosition
                {
                    Id = Guid.Parse("34082404-0c92-40a7-98f3-691159e61a0b"),
                    Code = "deputy-director",
                    NameRu = "Заместитель директора",
                    NameKk = "Заместитель директора"
                },
                new DicPosition
                {
                    Id = Guid.Parse("bb9f2320-bdd7-4083-9589-897c21eaae34"),
                    Code = "jurist-consultant",
                    NameRu = "Юристконсульт филиала",
                    NameKk = "Юристконсульт филиала"
                },
                new DicPosition
                {
                    Id = Guid.Parse("d04cea35-1965-484c-8cff-daa0c3aa44b7"),
                    Code = "risk-manager",
                    NameRu = "Риск-менеджер филиала",
                    NameKk = "Риск-менеджер филиала"
                },
                new DicPosition
                {
                    Id = Guid.Parse("4cfc6d3d-5bdb-44bd-a059-c216d7e88624"),
                    Code = "appraiser",
                    NameRu = "Специалист-оценщик филиала",
                    NameKk = "Специалист-оценщик филиала"
                },
                new DicPosition
                {
                    Id = Guid.Parse("148064c7-1247-484a-a1de-a43d6df9b262"),
                    Code = "manager",
                    NameRu = "Менеджер",
                    NameKk = "Менеджер"
                },
            });
        }

        #endregion
    }
}
