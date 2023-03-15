using Agro.Shared.Data.Repos.OutService;
using Autofac;
using System.Linq;
using System.Reflection;

namespace Agro.Scoring.Api
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.Load(new AssemblyName("Agro.Scoring.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<OutServiceRepo>().As<IOutServiceRepo>().InstancePerLifetimeScope();
            builder.RegisterModule<Logic.AutofacModule>();
        }
    }
}
