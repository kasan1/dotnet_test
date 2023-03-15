using System;
using System.Net.Http;
using Agro.Shared.Logic.Camunda;
using Agro.Integration.Logic.OutService;
using Agro.Shared.Logic.OutService.PKB;
using Agro.Shared.Logic.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Agro.Shared.Data.Repos.Jurist;
using Agro.Identity.Logic;
using Agro.Shared.Data.Repos.User;
using Agro.Shared.Logic.GKB;

namespace Agro.Bpm.Logic.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCamundaService(this IServiceCollection services)
        {
            return services
                    .AddTransient<IProcessLogic, ProcessLogic>();
        }

        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {

            var pkb = IntegrationType.PKB.ToString();
            services.AddHttpClient(pkb, client =>
            {
                client.BaseAddress = new Uri(configuration[$"AppSettings:Integrations:{pkb}:Url"]);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{configuration[$"AppSettings:Integrations:{pkb}:Login"]}:{configuration[$"AppSettings:Integrations:{pkb}:Password"]}")}");
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(EncoderHelper.GetRetryPolicy());

            var gkb = IntegrationType.GKB.ToString();
            services.AddHttpClient(gkb, client =>
            {
                client.BaseAddress = new Uri(configuration[$"AppSettings:Integrations:{gkb}:Url"]);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{configuration[$"AppSettings:Integrations:{gkb}:Login"]}:{configuration[$"AppSettings:Integrations:{gkb}:Password"]}")}");
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(EncoderHelper.GetRetryPolicy());

            var c1 = "C1";
            services.AddHttpClient(c1, client =>
            {
                client.BaseAddress = new Uri(configuration[$"AppSettings:Integrations:{c1}:Url"]);
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{configuration[$"AppSettings:Integrations:{c1}:Login"]}:{configuration[$"AppSettings:Integrations:{c1}:Password"]}")}");
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(EncoderHelper.GetRetryPolicy());

            services.AddTransient<IPKBLogic, PKBLogic>();
            services.AddTransient<IGKBLogic, GKBLogic>();
            services.AddTransient<IJuristResultRepo, JuristResultRepo>();
            
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<IIdentityLogic, IdentityLogic>();

            return services;
        }
    }
}
