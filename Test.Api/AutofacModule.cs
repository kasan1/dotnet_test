using Agro.Shared.Data.Repos.Client;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.User;
using Autofac;
using System.Linq;
using System.Reflection;
using Agro.Shared.Data.Repos.Branch;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Data.Repos.Dictionary;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Repos.LoanApplicationHistory;
using Agro.Shared.Data.Repos.Jurist;
using Agro.Shared.Data.Repos.FinAnalysis;
using Agro.Shared.Logic.Dictionary;
using Agro.Shared.Data.Repos.UserRole;
using Agro.Shared.Data.Repos.CreditCommitteeResult;
using Agro.Shared.Data.Repos.LoanApplicationTask;
using Agro.Shared.Data.Repos.Role;
using Agro.Shared.Data.Repos.Expertise;
using Agro.Admin.Logic.User;
using Agro.Shared.Data.Repos;
using Agro.Shared.Data.Repos.ClientDetailsRepo;
using Agro.Shared.Data.Repos.Dictionary.Accessories;
using Agro.Shared.Data.Repos.Dictionary.TechItems;
using Agro.Shared.Data.Repos.Dictionary.TechType;
using Agro.Shared.Data.Repos.ExcelAction;
using Agro.Scoring.Logic.FinAnalysis;
using Agro.Okaps.Logic;

namespace Agro.Okaps.Api
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("Agro.Okaps.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Dictionary
            builder.RegisterType<DictionaryLogic>().As<IDictionaryLogic>().InstancePerLifetimeScope();

            // Shared 
            builder.RegisterType<ProcessLogic>().As<IProcessLogic>().InstancePerLifetimeScope();
            builder.RegisterType<UserLogic>().As<IUserLogic>().InstancePerLifetimeScope();

            // Repos
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<LoanApplicationRepo>().As<ILoanApplicationRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ClientProfileRepo>().As<IClientProfileRepo>().InstancePerLifetimeScope();
            builder.RegisterType<BranchRepo>().As<IBranchRepo>().InstancePerLifetimeScope();
            builder.RegisterType<DictionaryRepo<DicClassificationSubtitle>>().As<IDictionaryRepo<DicClassificationSubtitle>>().InstancePerLifetimeScope();
            builder.RegisterType<DictionaryRepo<DicWarningClassification>>().As<IDictionaryRepo<DicWarningClassification>>().InstancePerLifetimeScope();
            builder.RegisterType<LoanApplicationHistoryRepo>().As<ILoanApplicationHistory>().InstancePerLifetimeScope();
            builder.RegisterType<JuristResultRepo>().As<IJuristResultRepo>().InstancePerLifetimeScope();
            builder.RegisterType<FinAnalysisRepo>().As<IFinAnalysisRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserRoleRepo>().As<IUserRoleRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreditCommitteeResultRepo>().As<ICreditCommitteeResultRepo>().InstancePerLifetimeScope();
            builder.RegisterType<LoanApplicationTaskRepo>().As<ILoanApplicationTaskRepo>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepo>().As<IRoleRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ExpertiseResultRepo>().As<IExpertiseResultRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<DicTechItemsRepo>().As<IDicTechItemsRepo>().InstancePerLifetimeScope();
            builder.RegisterType<DicTechTypeRepo>().As<IDicTechTypeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<AccessoriesRepo>().As<IAccessoriesRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ExcelRepo>().As<IExcelRepo>().InstancePerLifetimeScope();
            builder.RegisterType< Agro.Shared.Data.Repos.AppActives>().As<IAppActives>().InstancePerLifetimeScope();
            builder.RegisterType<ClientDetail>().As<IClientDetail>().InstancePerLifetimeScope();
            builder.RegisterType<FloraCulture>().As<IFloraCulture>().InstancePerLifetimeScope();

            builder.RegisterType<FinAnalysisLogic>().As<IFinAnalysisLogic>().InstancePerLifetimeScope();
            builder.RegisterType<FinAnalysResultLogic>().As<IFinAnalysResultLogic>().InstancePerLifetimeScope();
           
        }
    }
}
