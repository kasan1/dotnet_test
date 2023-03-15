using System;
using System.Linq;
using Agro.Integration.Api.BackgroundServices;
using Agro.Integration.Logic.OutService;
using Agro.Integration.Logic.OutService.C1Service;
using Agro.Shared.Logic.Primitives;
using Agro.Shared.Api;
using Agro.Shared.Data;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Repos;
using Agro.Shared.Data.Repos.Dictionary;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Integration.Api
{
    public class Startup : StartupShared
    {
        private readonly IConfiguration _configuration;
        private IOptions<C1IntegrationOption> _c1IntegrationOption;
        public Startup(IConfiguration configuration, IHostEnvironment hosting) : base(configuration, hosting)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddRepositories(services);
            foreach (var _ in Enum.GetValues(typeof(IntegrationType)).Cast<IntegrationType>().Select(v => v.ToString()).ToList())
            {
                services.AddHttpClient(_, client =>
                {
                    client.BaseAddress = new Uri(Configuration[$"AppSettings:Integrations:{_}:Url"]);
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{Configuration[$"AppSettings:Integrations:{_}:Login"]}:{Configuration[$"AppSettings:Integrations:{_}:Password"]}")}");
                }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(EncoderHelper.GetRetryPolicy());
            }

            services.AddScoped<DictionarySyncLogic>();

            services.Configure<C1IntegrationOption>(options => _configuration.GetSection(nameof(C1IntegrationOption)).Bind(_c1IntegrationOption));
            // var logic = new DictionarySyncLogic(
            //     Configuration[$"AppSettings:C1IntegrationOptions:Url"],
            //     Configuration[$"AppSettings:C1IntegrationOptions:Login"],
            //     Configuration[$"AppSettings:C1IntegrationOptions:Password"],
            //     UnitOfWork
            // );

            services.AddHostedService<DictionarySyncHostedService>();
            base.ConfigureServices(services, new[] { UserAudienceType.Int.ToString() });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<AutofacModule>();
            base.ConfigureContainer(containerBuilder);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
        }

        private static void AddRepositories(IServiceCollection services){
			services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
			services.AddScoped(typeof(IBaseRepo<>), typeof(DictionaryRepo<>));
		}
    }
}
