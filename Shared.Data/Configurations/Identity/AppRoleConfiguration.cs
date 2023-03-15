using System;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agro.Shared.Data.Configurations.Identity
{
    /// <summary>
    /// Role entity configurations
    /// </summary>
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(e => e.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getDate()")
                .IsRequired();

            builder.Property(e => e.ModifiedDate)
                .ValueGeneratedOnUpdate();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.NameRu)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.NameKk)
                .HasMaxLength(100);

            builder.Property(e => e.RoleType)
                .HasConversion<int>()
                .IsRequired();

            builder.HasIndex(e => e.IsDeleted);
            builder.HasQueryFilter(e => !e.IsDeleted);

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole[]
            {
                new AppRole
                {
                    Id = Guid.Parse("09704848-58D2-47D4-8939-08D86FFEDB1D"),
                    ConcurrencyStamp = "09704848-58D2-47D4-8939-08D86FFEDB1D",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpperInvariant(),
                    NameRu = "Администратор",
                    RoleType = RoleType.Admin
                },
                new AppRole
                {
                    Id = Guid.Parse("04239152-33AF-4071-8B84-686660C6C151"),
                    ConcurrencyStamp = "04239152-33AF-4071-8B84-686660C6C151",
                    Name = "CreditManager",
                    NormalizedName = "CreditManager".ToUpperInvariant(),
                    NameRu = "Кредит менеджер",
                    RoleType = RoleType.CreditManager
                },
                new AppRole
                {
                    Id = Guid.Parse("BAFC5489-4359-49ED-D251-08D8E1ECBA81"),
                    ConcurrencyStamp = "BAFC5489-4359-49ED-D251-08D8E1ECBA81",
                    Name = "CreditCommittee",
                    NormalizedName = "CreditCommittee".ToUpperInvariant(),
                    NameRu = "Кредитный комитет",
                    RoleType = RoleType.CreditCommittee
                },
                new AppRole
                {
                    Id = Guid.Parse("6B20B2F2-2FBE-4D6F-91E5-F1E5C1DB8E90"),
                    ConcurrencyStamp = "6B20B2F2-2FBE-4D6F-91E5-F1E5C1DB8E90",
                    Name = "CreditCommittee1",
                    NormalizedName = "CreditCommittee1".ToUpperInvariant(),
                    NameRu = "Кредитный комитет",
                    RoleType = RoleType.CreditCommittee1
                },
                new AppRole
                {
                    Id = Guid.Parse("380CAD1C-20C1-44F5-AF25-606B2BE0EA48"),
                    ConcurrencyStamp = "380CAD1C-20C1-44F5-AF25-606B2BE0EA48",
                    Name = "CreditCommittee2",
                    NormalizedName = "CreditCommittee2".ToUpperInvariant(),
                    NameRu = "Кредитный комитет",
                    RoleType = RoleType.CreditCommittee2
                },
                new AppRole
                {
                    Id = Guid.Parse("883A571B-58BF-4B70-A324-7ADB7BB1FA81"),
                    ConcurrencyStamp = "883A571B-58BF-4B70-A324-7ADB7BB1FA81",
                    Name = "CreditCommittee3",
                    NormalizedName = "CreditCommittee3".ToUpperInvariant(),
                    NameRu = "Кредитный комитет",
                    RoleType = RoleType.CreditCommittee3
                },
                new AppRole
                {
                    Id = Guid.Parse("3DEBEA62-3B35-485C-988F-421105B1BBEA"),
                    ConcurrencyStamp = "3DEBEA62-3B35-485C-988F-421105B1BBEA",
                    Name = "CreditCommittee4",
                    NormalizedName = "CreditCommittee4".ToUpperInvariant(),
                    NameRu = "Кредитный комитет",
                    RoleType = RoleType.CreditCommittee4
                },
                new AppRole
                {
                    Id = Guid.Parse("8D033B74-856F-4FA4-95C5-EA7B55C8A4CE"),
                    ConcurrencyStamp = "8D033B74-856F-4FA4-95C5-EA7B55C8A4CE",
                    Name = "CreditCommittee5",
                    NormalizedName = "CreditCommittee5".ToUpperInvariant(),
                    NameRu = "Кредитный комитет",
                    RoleType = RoleType.CreditCommittee5
                },
                new AppRole
                {
                    Id = Guid.Parse("2F237466-B4F1-48B9-B14C-B6CF717ED224"),
                    ConcurrencyStamp = "2F237466-B4F1-48B9-B14C-B6CF717ED224",
                    Name = "Pledger",
                    NormalizedName = "Pledger".ToUpperInvariant(),
                    NameRu = "Залогодатель",
                    RoleType = RoleType.Pledger
                },
                new AppRole
                {
                    Id = Guid.Parse("26B33317-91D0-42B8-905D-08D8E1EA76A3"),
                    ConcurrencyStamp = "26B33317-91D0-42B8-905D-08D8E1EA76A3",
                    Name = "CredAdmin",
                    NormalizedName = "CredAdmin".ToUpperInvariant(),
                    NameRu = "Кредитный администратор",
                    RoleType = RoleType.CredAdmin
                },
                new AppRole
                {
                    Id = Guid.Parse("5FB9F021-E553-46B3-BEE4-E3D96F995E80"),
                    ConcurrencyStamp = "5FB9F021-E553-46B3-BEE4-E3D96F995E80",
                    Name = "Purchaser",
                    NormalizedName = "Purchaser".ToUpperInvariant(),
                    NameRu = "Закупщик",
                    RoleType = RoleType.Purchaser
                },
                new AppRole
                {
                    Id = Guid.Parse("C6D623FC-ECC9-4C8A-8F01-0C543AAB70D9"),
                    ConcurrencyStamp = "C6D623FC-ECC9-4C8A-8F01-0C543AAB70D9",
                    Name = "Jurist",
                    NormalizedName = "Jurist".ToUpperInvariant(),
                    NameRu = "Юрист",
                    RoleType = RoleType.Jurist
                },
                new AppRole
                {
                    Id = Guid.Parse("FC7A5055-4E94-4CF5-9B6F-1ED968EF425F"),
                    ConcurrencyStamp = "FC7A5055-4E94-4CF5-9B6F-1ED968EF425F",
                    Name = "SecurityManager",
                    NormalizedName = "SecurityManager".ToUpperInvariant(),
                    NameRu = "Менеджер по безопасности (СБ)",
                    RoleType = RoleType.SecurityManager
                },
                new AppRole
                {
                    Id = Guid.Parse("AECF3004-49CA-4B71-B5C6-E0C69373AF28"),
                    ConcurrencyStamp = "AECF3004-49CA-4B71-B5C6-E0C69373AF28",
                    Name = "RiskManager",
                    NormalizedName = "RiskManager".ToUpperInvariant(),
                    NameRu = "Риск менеджер",
                    RoleType = RoleType.RiskManager
                },
                new AppRole
                {
                    Id = Guid.Parse("8F7F4E3C-D607-4060-47C1-08D91F280430"),
                    ConcurrencyStamp = "8F7F4E3C-D607-4060-47C1-08D91F280430",
                    Name = "ComplianceManager",
                    NormalizedName = "ComplianceManager".ToUpperInvariant(),
                    NameRu = "Комплеанс менеджер",
                    RoleType = RoleType.ComplianceManager
                },
                new AppRole
                {
                    Id = Guid.Parse("5E41BC02-51D1-4FFF-8F11-BEF3E042CB75"),
                    ConcurrencyStamp = "5E41BC02-51D1-4FFF-8F11-BEF3E042CB75",
                    Name = "CreditCommitteeChairman",
                    NormalizedName = "CreditCommitteeChairman".ToUpperInvariant(),
                    NameRu = "Председатель кредитного комитета",
                    RoleType = RoleType.CreditCommitteeChairman
                },
                new AppRole
                {
                    Id = Guid.Parse("3386622F-39AE-48D0-87FC-58653C60AE6B"),
                    ConcurrencyStamp = "3386622F-39AE-48D0-87FC-58653C60AE6B",
                    Name = "Logist",
                    NormalizedName = "Logist".ToUpperInvariant(),
                    NameRu = "Логист",
                    RoleType = RoleType.Logist
                }
            });
        }
    }
}
