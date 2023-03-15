using System;
using System.Linq;
using System.Net.Http;
using Agro.Admin.Logic.User;
using Agro.Integration.Logic.OutService;
using Agro.Integration.Logic.OutService.ASP;
using Agro.Integration.Logic.OutService.GCVP;
using Agro.Integration.Logic.OutService.ZAGS;
using Agro.Okaps.Logic;
using Agro.Scoring.Logic.Scoring;
using Agro.Shared.Api;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Data.Repos;
using Agro.Shared.Data.Repos.Branch;
using Agro.Shared.Data.Repos.Client;
using Agro.Shared.Data.Repos.ClientDetailsRepo;
using Agro.Shared.Data.Repos.CreditCommitteeResult;
using Agro.Shared.Data.Repos.Dictionary;
using Agro.Shared.Data.Repos.Dictionary.Accessories;
using Agro.Shared.Data.Repos.Dictionary.TechItems;
using Agro.Shared.Data.Repos.Dictionary.TechType;
using Agro.Shared.Data.Repos.ExcelAction;
using Agro.Shared.Data.Repos.Expertise;
using Agro.Shared.Data.Repos.FinAnalysis;
using Agro.Shared.Data.Repos.Jurist;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.LoanApplicationHistory;
using Agro.Shared.Data.Repos.LoanApplicationTask;
using Agro.Shared.Data.Repos.Role;
using Agro.Shared.Data.Repos.User;
using Agro.Shared.Data.Repos.UserRole;
using Agro.Shared.Logic;
using Agro.Shared.Logic.Dictionary;
using Agro.Shared.Logic.GKB;
using Agro.Shared.Logic.OutService.PKB;
using Agro.Shared.Logic.Primitives;
using Agro.Shared.Logic.Services.Calculator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Agro.Okaps.Api
{
    public class Startup : StartupShared
    {
        public Startup(IConfiguration configuration, IHostEnvironment hosting) : base(configuration, hosting)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services, new[] { UserAudienceType.Int.ToString(), UserAudienceType.Ext.ToString() });
            foreach (var _ in Enum.GetValues(typeof(IntegrationType)).Cast<IntegrationType>().Select(v => v.ToString()).ToList())
            {
                services.AddHttpClient(_, client =>
                {
                    client.BaseAddress = new Uri(Configuration[$"AppSettings:Integrations:{_}:Url"]);
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{Configuration[$"AppSettings:Integrations:{_}:Login"]}:{Configuration[$"AppSettings:Integrations:{_}:Password"]}")}");
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(EncoderHelper.GetRetryPolicy())
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (m, crt, chn, e) => true
                    };
                });
            }

            services.AddOkapsLogic(Configuration);

            services.AddTransient<IPrintLogic, PrintLogic>();

            // Dictionary
            services.AddTransient<IDictionaryLogic, DictionaryLogic>();

            // Shared 
            services.AddTransient<IUserLogic, UserLogic>();

            // Repos
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<ILoanApplicationRepo, LoanApplicationRepo>();
            services.AddTransient<IClientProfileRepo, ClientProfileRepo>();
            services.AddTransient<IDictionaryRepo<DicClassificationSubtitle>, DictionaryRepo<DicClassificationSubtitle>> ();
            services.AddTransient<IDictionaryRepo<DicWarningClassification>, DictionaryRepo<DicWarningClassification>>();
            services.AddTransient<ILoanApplicationHistory, LoanApplicationHistoryRepo>();
            services.AddTransient<IJuristResultRepo, JuristResultRepo>();
            services.AddTransient<IFinAnalysisRepo, FinAnalysisRepo>();
            services.AddTransient<IUserRoleRepo, UserRoleRepo>();
            services.AddTransient<ICreditCommitteeResultRepo, CreditCommitteeResultRepo>();
            services.AddTransient<ILoanApplicationTaskRepo, LoanApplicationTaskRepo>();
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IExpertiseResultRepo, ExpertiseResultRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IDicTechItemsRepo, DicTechItemsRepo>();
            services.AddTransient<IDicTechTypeRepo, DicTechTypeRepo>();
            services.AddTransient<IAccessoriesRepo, AccessoriesRepo>();
            services.AddTransient<IExcelRepo, ExcelRepo>();
            services.AddTransient<IAppActives, Shared.Data.Repos.AppActives>();
            services.AddTransient<IClientDetail, ClientDetail>();
            services.AddTransient<IFloraCulture, Shared.Data.Repos.FloraCulture>();
            services.AddTransient<IBranchRepo, BranchRepo>();
            services.AddTransient<IGCVPCheckLogic, GCVPCheckLogic>();

            // Logic
            services.AddTransient<IClientProfileLogic, ClientProfileLogic>();
            services.AddTransient<IExpetiseResultLogic, ExpetiseResultLogic>();
            services.AddTransient<IFinAnalysResultLogic, FinAnalysResultLogic>();
            services.AddTransient<IASPLogic, ASPLogic>();
            services.AddTransient<IZAGSLogic, ZAGSLogic>();
            services.AddTransient<IPKBLogic, PKBLogic>();
            services.AddTransient<IGKBLogic, GKBLogic>();
            services.AddTransient<IGCVPLogic, GCVPLogic>();
            services.AddTransient<IOverdueCheckLogic, OverdueCheckLogic>();
            services.AddTransient<IFinAnalysResultLogic, FinAnalysResultLogic>();
            services.AddTransient<ICalculator, Shared.Logic.Services.Calculator.Calculator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
        }
    }
}
