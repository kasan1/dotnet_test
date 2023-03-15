using System;
using Agro.Shared.Data.Configurations.Base;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.System
{
    public class DicRelationWithCompanyConfiguration : BaseDictionaryConfigurations<DicRelationWithCompany>
    {
        #region Public functions

        /// <summary>
        /// Configures the entity of type TEntity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public override void Configure(EntityTypeBuilder<DicRelationWithCompany> builder)
        {
            base.Configure(builder);
            SeedData(builder);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Seeds values into database
        /// </summary>
        /// <param name="builder">Instance of <see cref="EntityTypeBuilder{DicRelationWithCompany}"/></param>
        public static void SeedData(EntityTypeBuilder<DicRelationWithCompany> builder)
        {
            builder.HasData(
                new DicRelationWithCompany { Id = Guid.Parse("53145ABC-A5B4-4E2A-8A8F-64BC353FD5F2"), Code = "51", NameRu = "Связан не исп", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("28D70007-CBF2-4CA1-8AD7-87380C3DF261"), Code = "50", NameRu = "Не связан", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("69AC17AA-13F4-4464-9A73-6CF1119C130D"), Code = "12", NameRu = "Должностное лицо или руководящий работник банка (организации, осуществляющей отд", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("97250CED-612D-4DD7-A6F6-B57A40E4EDC8"), Code = "13", NameRu = "Близкий родственник должностного лица или руководящего работника банка", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("444DD655-4A34-4063-95A1-FBE7F5D12834"), Code = "16", NameRu = "Крупный участник банка", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("E9470491-55A2-4EB1-A653-984491C9A38D"), Code = "18", NameRu = "Должностное лицо крупного участника банка", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("251967FA-AC3B-4C10-8EBB-2230F3D26ED7"), Code = "06", NameRu = "Близкий родственник должностного лица крупного участника банка", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("99F737CF-D0A8-4D5D-B2AD-22A39465195A"), Code = "20", NameRu = "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("0F4298E1-4177-4306-AF65-E20643DB1D35"), Code = "22", NameRu = "Должностное лицо юридического лица, по отношению к которому банк является крупны", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("4753AC66-3704-4F9E-AF2C-5271D77FA971"), Code = "23", NameRu = "Близкий родственник должностного лица юридического лица, по отношению к ко-тором", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("CD231CA4-D76F-47EE-935E-CB11A53EDF56"), Code = "21", NameRu = "Юридическое лицо, в котором главный бухгалтер филиала банка  (организации, осуще", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("534123EF-9881-441A-9EA2-624AFA68BA3C"), Code = "42", NameRu = "Крупный участник крупного участника банка, банковского холдинга", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("B95AAFAB-E501-46A4-8B6A-9B6993040A1E"), Code = "44", NameRu = "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся к", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("71DE6CD0-353A-4894-A75A-14BE1F764A0C"), Code = "41", NameRu = "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся г", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("28CFDC7C-995A-41BB-9A57-1502B7D8748D"), Code = "46", NameRu = "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся д", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("401FF648-D1F7-4778-9CF4-F075DF8265B5"), Code = "45", NameRu = "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся к", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("6297E3D4-F6A3-4698-8BC6-A06BC5C120B3"), Code = "39", NameRu = "Лицо, состоящее в близком родстве, браке, а также свойстве с лицом, являющимся п", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("F64A44D3-0BA6-41C7-8B89-AFBE726CA051"), Code = "35", NameRu = "Главный бухгалтер филиала банка  (организации, осуществляющей отдельные виды бан", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("EEA13AD1-280D-4ACE-8DDB-9AFDE9A8DB4C"), Code = "43", NameRu = "Должностное лицо крупного акционера организации, осуществляющей отдельные виды б", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("81216E55-DB6E-4DDC-AF1B-95E64457C93D"), Code = "78", NameRu = "Должностное лицо юридического лица, которое контролируется должностным лицом бан", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("17B7B008-B96E-4A02-BA6E-7913BFA72DD0"), Code = "79", NameRu = "Должностное лицо юридического лица, которое контролируется должностным лицом бан", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("BAF15E3C-9423-4786-9C8B-41338530CD7A"), Code = "77", NameRu = "Должностное лицо юридического лица, которое контролируется крупным акционером ор", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("4D05865A-8417-46E7-9AEE-B9CF71B5EAB5"), Code = "76", NameRu = "Должностное лицо юридического лица, которое контролируется крупным участником ба", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("0124802C-F147-4504-B0FA-BBAC7054DEDA"), Code = "80", NameRu = "Иное лицо, связанное с банком (организацией, осуществляющей отдельные виды банко", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("9B2E900D-208D-44C3-AAEE-55607A1C34A3"), Code = "59", NameRu = "Крупный акционер (участник) организации, осуществляющей отдельные виды банковски", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("421B39D2-17CF-480F-BC71-D00A4C717DC4"), Code = "60", NameRu = "Крупный участник (акционер) крупного участника (акционера) организации, осуществ", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("9D95DEC1-FB27-404A-85E8-2099DC6DC3E9"), Code = "66", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("FF98992D-F404-4025-9262-AC6C859ACA76"), Code = "67", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("7CFE085B-F7D2-43A2-B743-189572168B0E"), Code = "68", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("927F02BE-7198-4A1D-996A-72D042A37E00"), Code = "69", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("D13BDE36-4612-4FD9-8E73-588EF8B84C54"), Code = "70", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("9040B8A5-90E6-48DE-9845-0B2D20C7CEF2"), Code = "71", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("3F12E6F2-4D35-4255-A7DD-0EC5973C2741"), Code = "72", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("6ACA42C6-99BF-4C5C-87A7-9304FAAB71F7"), Code = "73", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("8473C3BA-37A3-45B5-B439-DEC78DCA145E"), Code = "74", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("A846B2EC-02A9-4872-8BDF-A2BD16A83CAF"), Code = "75", NameRu = "Лицо, которое самостоятельно или совместно со своими аффилиированными лицами вла", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("F64E5FD1-EEE3-4F25-B170-A10411A2F73D"), Code = "65", NameRu = "Лицо, связанное с банком  (организации, осуществляющей отдельные виды банковских", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("6AD3241E-D59E-4A8C-BAB7-6D9C72AE1531"), Code = "34", NameRu = "Первый руководитель филиала банка  (организации, осуществляющей отдельные виды б", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("235E210A-EFB3-4948-8FE1-2101E921D2FC"), Code = "56", NameRu = "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("2ECCC65F-A08D-4435-9672-B10767D6BE28"), Code = "54", NameRu = "Юридическое лицо, в котором должностное лицо крупного участника банка (организац", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("D5049A82-1230-47C7-901A-A25D8223A829"), Code = "47", NameRu = "Юридическое лицо, в котором должностное лицо или руководящий работник банка (орг", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("17FA4259-0515-4C4D-88F6-8CF96C740880"), Code = "24", NameRu = "Юридическое лицо, в котором крупный участник банка является крупным участником (", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("E885AD91-D564-4541-8678-A4453944A715"), Code = "52", NameRu = "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("F47074E1-554F-484D-8077-022F0E76272D"), Code = "53", NameRu = "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("D824F24F-9436-44FB-9DCA-EBEE194CED74"), Code = "57", NameRu = "Юридическое лицо, в котором лицо, состоящее в близком родстве, браке, а также св", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("A34F4E99-1201-4571-A83F-101984E06266"), Code = "48", NameRu = "Юридическое лицо, в котором первый руководитель филиала банка  (организации, осу", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("4F2088FA-ED57-4A38-9298-D048B25EE38E"), Code = "63", NameRu = "Юридическое лицо, которое контролируется лицом, являющимся должностным лицом бан", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("BAE8172D-6159-459F-B7F9-CA5E8C0EA908"), Code = "62", NameRu = "Юридическое лицо, которое контролируется лицом, являющимся крупным акционером (у", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("4223EF34-BEFF-4D70-B166-A2E0DF19B88E"), Code = "61", NameRu = "Юридическое лицо, которое контролируется лицом, являющимся крупным участником ба", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("2DB87D97-D704-42CD-AB9F-263AC59D762B"), Code = "64", NameRu = "Юридическое лицо, которое совместно с банком (организации, осуществляющей отдель", NameKk = "" },
                new DicRelationWithCompany { Id = Guid.Parse("5E9911C7-D9FF-4B14-950C-9C25CF0F58BB"), Code = "58", NameRu = "Юридическое лицо, по отношению к которому банк  (организация, осуществляющая отд", NameKk = "" }
            );
        }

        #endregion
    }
}
