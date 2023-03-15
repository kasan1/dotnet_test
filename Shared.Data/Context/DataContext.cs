using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.ClientExtraDetails;
using Agro.Shared.Data.Entities.Dictionaries;
using Agro.Shared.Data.Entities.FinAnalysis;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Entities.System;
using Agro.Shared.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Agro.Shared.Data.Entities.Notifications;

namespace Agro.Shared.Data.Context
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>, IMigrationContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region Entities

        public DbSet<User> Users { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Agreement> Agreements { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        // public DbSet<DicBranch> DicBranches { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleControls> RoleControls { get; set; }
        public DbSet<RoleControlsField> RoleControlsFields { get; set; }
        public DbSet<RoleControlsFieldValue> RoleControlsFieldValues { get; set; }
        public DbSet<RoleControlsButton> RoleControlsButtons { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<OutService> OutServices { get; set; }



        // Dictionaries
        public DbSet<DicPosition> DicPositions { get; set; }
        public DbSet<DicLoanProduct> DicLoanProducts { get; set; }

        public DbSet<DicLoanRepaymentType> DicLoanRepaymentTypes { get; set; }
        public DbSet<DicClientLocationType> DicClientLocationTypes { get; set; }
        public DbSet<DicClientSegment> DicClientSegmentes { get; set; }
        public DbSet<DicClientType> DicClientTypes { get; set; }        
        public DbSet<DicAgriculturalMachineryPurpose> DicAgriculturalMachineryPurpose { get; set; }
        public DbSet<DicEquipmentPurpose> DicEquipmentPurpose { get; set; }
        public DbSet<DicLandPurpose> DicLandPurpose { get; set; }
        public DbSet<DicCommercialObjectName> DicCommercialОbjectName { get; set; }
        public DbSet<DicCommercialObjectPurpose> DicCommercialОbjectPurpose { get; set; }
        public DbSet<DicCommercialObjectType> DicCommercialОbjectType { get; set; }
        public DbSet<DicRegion> DicRegions { get; set; }

        public DbSet<DicStockType> DicStockType { get; set; }
        public DbSet<DicTransportBodyType> DicTransportBodyType { get; set; }
        public DbSet<DicTransportFuel> DicTransportFuel { get; set; }
        public DbSet<DicTransportSteeringWheel> DicTransportSteeringWheel { get; set; }
        public DbSet<DicTransportType> DicTransportType { get; set; }
        public DbSet<DicWallMaterial> DicWallMaterial { get; set; }
        public DbSet<DicGuaranteeType> DicGuaranteeType { get; set; }
        public DbSet<DicFileType> DicFileTypes { get; set; }
        public DbSet<DicDocumentType> DicDocumentTypes { get; set; }
        public DbSet<DicCountry> DicCountries { get; set; }
        public DbSet<DicNok> DicNoks { get; set; }
        public DbSet<DicFirstDocType> DicFirstDocTypes { get; set; }
        public DbSet<DicPledgeType> DicPledgeTypes { get; set; }

        public DbSet<DicDocClassification> DicDocClassifications { get; set; }
        public DbSet<DicClassificationSubtitle> DicClassificationSubtitles { get; set; }
        public DbSet<DicWarningClassification> DicWarningClassifications { get; set; }
        public DbSet<DicLoanHistoryStatus> DicLoanHistoryStatuses { get; set; }
        public DbSet<DicTaskStatus> DicTaskStatuses { get; set; }
        public DbSet<DicDecision> DicDecisions { get; set; }
        public DbSet<DicClientCategory> DicClientCategories { get; set; }

        public DbSet<DicTechType> DicTechTypes { get; set; }
        public DbSet<DicProvider> DicProviders { get; set; }

        public DbSet<DicTechModel> DicTechModels { get; set; }
        public DbSet<DicVerificationStatus> DicVerificationStatuses { get; set; }

        public DbSet<Calculator> Calculators { get; set; }
        public DbSet<Contract> Contracts { get; set; }
                
        public DbSet<SelectedAccessory> SelectedAccessories { get; set; }
        public DbSet<SelectedTechnic> SelectedTechnics { get; set; }

        public DbSet<FloraCulture> FloraCultures { get; set; }

        public DbSet<DicTechProduct> DicTechProducts { get; set; }
        public DbSet<DicCountryTechModel> DicCountryTechModels { get; set; }
        public DbSet<DicCountryProvider> DicCountryProviders { get; set; }
                
        public DbSet<DicLoanType> DicLoanTypes { get; set; }
        public DbSet<DicAccessories> DicAccessorieses { get; set; }

        public DbSet<DicTaxTreatment> DicTaxTreatments { get; set; }
        public DbSet<DicOrganizationAndLegalForm> DicOrganizationAndLegalForms { get; set; }
        public DbSet<DicSubjectOfEntrepreneur> DicSubjectOfEntrepreneur { get; set; }
        public DbSet<DicRelationWithCompany> DicRelationWithCompany { get; set; }
        public DbSet<DicTypeOfRelationWithCompany> DicTypeOfRelationWithCompany { get; set; }

        //public DbSet<DicBank> DicBanks { get; set; }

        // Заявки
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanApplicationHistory> LoanApplicationHistories { get; set; }
        public DbSet<LoanApplicationTask> LoanApplicationTasks { get; set; }


        //финанализ
        public DbSet<FinAnalysis> FinAnalyses { get; set; }
        public DbSet<FinAnalysisIncome> FinAnalysisIncomes { get; set; }
        public DbSet<FinAnalysisLoanPayment> FinAnalysisLoanPayments { get; set; }
        public DbSet<FinAnalysisQueueTask> FinAnalysisQueueTasks { get; set; }


        //юрист 
        public DbSet<JuristResult> JuristResults { get; set; }

        public DbSet<CreditCommitteeResult> CreditCommitteeResults { get; set; }

        //экспертиза 
        public DbSet<ExpertiseResult> ExpertiseResults { get; set; }

        public DbSet<Comment> Comments { get; set; }


        public DbSet<Entities.System.File> Files { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }


        //LoanAppliactionDetails
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditHistory> CreditHistory { get; set; }
        public DbSet<Dept> PersonalityDepts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PersonalityDocument> PersonalityDocuments { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationOKED> OrganizationOKED { get; set; }
        public DbSet<LoanApplications.Details> LoanApplicationDetails { get; set; }
        public DbSet<LoanApplications.DetailsPersonality> LoanApplicationDetailsPersonalities { get; set; }
        public DbSet<LoanApplications.Activity.Activity> Activities { get; set; }
        public DbSet<LoanApplications.Activity.FloraActivity>  FloraActivity { get; set; }
        public DbSet<LoanApplications.Activity.FloraProductivity> FloraProductivity { get; set; }
        public DbSet<LoanApplications.Activity.LandActivity> LandActivity { get; set; }
        public DbSet<LoanApplications.Activity.LivestockActivity> LivestockActivity { get; set; }
        public DbSet<LoanApplications.Activity.TechnicActivity> TechnicActivity { get; set; }

        public DbSet<ExtraDetails> LoanApplicationExtraDetails { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<UlOwner> UlOwners { get; set; }
        public DbSet<FlOwner> FlOwners { get; set; }

        public DbSet<DicMariageStatus> DicMariageStatuses { get; set; }
        public DbSet<DicOrganizationType>  DicOrganizationTypes { get; set; }
        public DbSet<DicOwnershipForm> DicOwnershipForms { get; set; }
        public DbSet<DicOKED> DicOKED { get; set; }
        public DbSet<DicOwnershipType> DicOwnershipTypes { get; set; }
        public DbSet<DicLandType> DicLandTypes { get; set; }
        public DbSet<DicLivestockType> DicLivestockTypes { get; set; }

        public DbSet<SpecialRelation> SpecialRelations { get; set; }
        public DbSet<AffiliationPersonality> AffiliationPersonalities { get; set; }

        public DbSet<DicProvisionType> DicProvisionTypes { get; set; }
        public DbSet<DicProvisionDescription> DicProvisionDescription { get; set; }
        public DbSet<Provision> Provisions { get; set; }
        public DbSet<DicContractStatus> DicContractStatus { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DicCheckingListType> DicCheckingListTypes { get; set; }

        public DbSet<CheckingList> CheckingList { get; set; }
        public DbSet<CheckingResult> CheckingResults { get; set; }

        #endregion

        #region Public functions

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(configurationBuilder.GetConnectionString("DefaultConnection"));
            }
        }

        /// <summary>
        /// Configures models that was discovered by convention from the entity types exposed in <see cref="DbSet{TEntity}"/>
        /// </summary>
        /// <param name="builder">Interface to define the shape of entities, relationship between them and how they map to database</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        public override int SaveChanges()
        {
            OnSaveChanges();
            return base.SaveChanges();
        }

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indicates whether ChangeTracker.AcceptAllChanges is called after the changes have been sent successfully to the database</param>
        /// <returns>The number of state entries written to the database</returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The number of state entries written to the database</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indicates whether ChangeTracker.AcceptAllChanges is called after the changes have been sent successfully to the database</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The number of state entries written to the database</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Applies values to entity's base fields depending on it's state change
        /// </summary>
        private void OnSaveChanges()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        if (entityEntry.CurrentValues.Properties.Any(p => p.Name == "ModifiedDate"))
                        {
                            entityEntry.CurrentValues["ModifiedDate"] = DateTime.UtcNow;
                        }
                        break;
                    case EntityState.Added:
                        if (entityEntry.CurrentValues.Properties.Any(p => p.Name == "CreatedDate"))
                        {
                            entityEntry.CurrentValues["CreatedDate"] = DateTime.UtcNow;
                        }
                        break;
                    case EntityState.Deleted:
                        if (entityEntry.CurrentValues.Properties.Any(p => p.Name == "CreatedDate") 
                            && entityEntry.CurrentValues.Properties.Any(p => p.Name == "IsDeleted"))
                        {
                            //entityEntry.CurrentValues[nameof(IChangeTrackingEntity.DateOfDelete)] = DateTime.UtcNow;
                            entityEntry.CurrentValues["IsDeleted"] = true;
                            entityEntry.State = EntityState.Modified;
                        }
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentNullException();
                }
            }
        }

        #endregion
    }
}
