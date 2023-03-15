using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agro.Integration.Logic.OutService;
using Agro.Shared.Logic.Primitives;
using Agro.Scoring.Api.BackgroundServices;
using Agro.Shared.Api;
using Agro.Shared.Data.Repos;
using Agro.Shared.Data.Repos.Dictionary;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Scoring.Api
{
    public class Startup : StartupShared
    {
        public Startup(IConfiguration configuration, IHostEnvironment hosting) : base(configuration, hosting)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            foreach (var _ in Enum.GetValues(typeof(IntegrationType)).Cast<IntegrationType>().Select(v => v.ToString()).ToList())
            {
                services.AddHttpClient(_, client =>
                {
                    client.BaseAddress = new Uri(Configuration[$"AppSettings:Integrations:{_}:Url"]);
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{Configuration[$"AppSettings:Integrations:{_}:Login"]}:{Configuration[$"AppSettings:Integrations:{_}:Password"]}")}");
                }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(EncoderHelper.GetRetryPolicy());
            }

            services.AddHostedService<FinAnalysisHostedService>();

            base.ConfigureServices(services, new[] { UserAudienceType.Int.ToString(), UserAudienceType.Ext.ToString() });
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
    }
}
