using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicOKEDConfiguration : BaseDictionaryConfigurations<DicOKED>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicOKED> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicOKED}"/></param>
        public static void SeedData(EntityTypeBuilder<DicOKED> builder)
        {
            builder.HasData(
                new DicMariageStatus
                {
                    Id = Guid.Parse("102a2954-ea3e-4e86-aea9-a43e8516e372"),
                    Code = "0111",
                    NameRu = "Выращивание зерновых (кроме риса), бобовых и масличных культур",
                    NameKk = "Дәнді дақылдарды (күріштен басқа), бұршақ және майлы дақылдарды өсіру"
                },
                new DicMariageStatus
                {
                    Id = Guid.Parse("8e27ebdf-16ea-4376-b74f-011c87a1877f"),
                    Code = "0113",
                    NameRu = "Выращивание овощей, бахчевых, корнеплодов и клубнеплодов",
                    NameKk = "Көкөністер, бақша дақылдарын, тамыр жемістілер мен түйнек жемістілерді өсіру"
                }
            );
        }

        #endregion
    }
}
