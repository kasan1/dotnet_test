using Agro.Integration.Logic.OutService.ASP;
using Agro.Integration.Logic.OutService.GCVP;
using Agro.Integration.Logic.OutService.GKB;
using Agro.Integration.Logic.OutService.ZAGS;
using Agro.Scoring.Logic.FinAnalysis;
using Agro.Shared.Data.Repos.FinAnalysis;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.User;
using Agro.Shared.Logic.Camunda;
using Autofac;

namespace Agro.Scoring.Logic
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ASPLogic>().As<IASPLogic>().InstancePerLifetimeScope();
            builder.RegisterType<ZAGSLogic>().As<IZAGSLogic>().InstancePerLifetimeScope();
            builder.RegisterType<GKBLogic>().As<IGKBLogic>().InstancePerLifetimeScope();
            builder.RegisterType<GCVPLogic>().As<IGCVPLogic>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessLogic>().As<IProcessLogic>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<LoanApplicationRepo>().As<ILoanApplicationRepo>().InstancePerLifetimeScope();
            builder.RegisterType<FinAnalysisQueueTaskRepo>().As<IFinAnalysisQueueTaskRepo>().InstancePerLifetimeScope();

            builder.RegisterType<FinAnalysisRepo>().As<IFinAnalysisRepo>().InstancePerLifetimeScope();
            builder.RegisterType<QueueScheduler>().As<IQueueScheduler>().SingleInstance();
        }
    }
}
