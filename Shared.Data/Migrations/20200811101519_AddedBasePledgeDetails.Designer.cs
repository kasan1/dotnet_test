﻿// <auto-generated />
using System;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agro.Shared.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200811101519_AddedBasePledgeDetails")]
    partial class AddedBasePledgeDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agro.Shared.Data.Context.CreditSources", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaxMonth")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxSumAnchor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PercentEffSocial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentEffStandart")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentSocial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PercentStandart")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CreditSources");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.Pledge.BasePledge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BpmNokId")
                        .HasColumnType("int");

                    b.Property<Guid?>("ChargeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CoreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasLegalTransactionsAndClaims")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCorrectEgov")
                        .HasColumnType("bit");

                    b.Property<string>("IsCorrectEgovNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrectLaw")
                        .HasColumnType("bit");

                    b.Property<string>("IsCorrectLawNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEncumbered")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEncumberedAtFund")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNokAssessment")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Kato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LiquidityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NokOrManualSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PledgeType")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChargeeId");

                    b.HasIndex("LiquidityId");

                    b.ToTable("BasePledge");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.Pledge.Chargee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DocumentDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DocumentDateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentIdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentIssuedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIOKaz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIORus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrectEgov")
                        .HasColumnType("bit");

                    b.Property<string>("IsCorrectEgovNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrectLaw")
                        .HasColumnType("bit");

                    b.Property<string>("IsCorrectLawNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegFlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegHouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegIndex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegRegion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegStreetKz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chargees");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.Pledge.Liquidity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Coefficient")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LiquidityType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PledgeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Liquidities");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Audience")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPhysical")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordTryCount")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignXml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.Pledge.BasePledge", b =>
                {
                    b.HasOne("Agro.Shared.Data.Context.Pledge.Chargee", "Chargee")
                        .WithMany("BasePledges")
                        .HasForeignKey("ChargeeId");

                    b.HasOne("Agro.Shared.Data.Context.Pledge.Liquidity", "Liquidity")
                        .WithMany("BasePledges")
                        .HasForeignKey("LiquidityId");
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.RolePermission", b =>
                {
                    b.HasOne("Agro.Shared.Data.Context.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.Shared.Data.Context.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agro.Shared.Data.Context.UserRole", b =>
                {
                    b.HasOne("Agro.Shared.Data.Context.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.Shared.Data.Context.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
