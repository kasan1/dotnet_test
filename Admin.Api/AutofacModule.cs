using Agro.Shared.Data.Repos.Dictionary.Nok;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.Role;
using Agro.Shared.Data.Repos.UserRole;
using Agro.Shared.Logic.Dictionary;
using Autofac;
using System.Linq;
using System.Reflection;

namespace Admin.Api
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("Agro.Admin.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<DictionaryLogic>().As<IDictionaryLogic>().InstancePerLifetimeScope();

            builder.RegisterType<UserRoleRepo>().As<IUserRoleRepo>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepo>().As<IRoleRepo>().InstancePerLifetimeScope();
            builder.RegisterType<DicNokRepo>().As<IDicNokRepo>().InstancePerLifetimeScope();
            builder.RegisterType<LoanApplicationRepo>().As<ILoanApplicationRepo>().InstancePerLifetimeScope();
        }
    }
}
