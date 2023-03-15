using Agro.Identity.Logic;
using Agro.Okaps.Logic;
using Agro.Shared.Data.Repos.Branch;
using Agro.Shared.Data.Repos.Client;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.OutService;
using Agro.Shared.Data.Repos.User;
using Autofac;
using GKBService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Agro.Integration.Api
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("Agro.Integration.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Agro.Identity.Logic
            builder.RegisterType<AccountLogic>().As<IAccountLogic>().InstancePerLifetimeScope();
            builder.RegisterType<IdentityLogic>().As<IIdentityLogic>().InstancePerLifetimeScope();
            // Agro.Okaps.Logic
            builder.RegisterType<ClientProfileLogic>().As<IClientProfileLogic>().InstancePerLifetimeScope();

            builder.RegisterType<OutServiceRepo>().As<IOutServiceRepo>().InstancePerLifetimeScope();
            builder.RegisterType<LoanApplicationRepo>().As<ILoanApplicationRepo>().InstancePerLifetimeScope();
            builder.RegisterType<BranchRepo>().As<IBranchRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ClientProfileRepo>().As<IClientProfileRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();


            builder.RegisterType<CreditReportInterfaceClient>().As<CreditReportInterface>().InstancePerLifetimeScope();
        }
    }
}
