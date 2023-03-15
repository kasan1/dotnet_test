using Agro.Shared.Api.Common.Extensions;
using Agro.Shared.Data;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Logic;
using Agro.Shared.Logic.Common.ActionFilters;
using Agro.Shared.Logic.Common.Localization;
using Autofac;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace Agro.Shared.Api
{
    /// <summary>
    /// Базовый startup
    /// </summary>
    public class StartupShared
    {
        private const string _corsPolicyName = "AllowAllOrigins"; 

        public StartupShared(IConfiguration configuration, IHostEnvironment env)
        {
            Environment = env;
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder
                .AddJsonFile("appsettings.shared.json")
                .AddJsonFile($"appsettings.shared.{env.EnvironmentName.Trim()}.json")
                .AddConfiguration(configuration);

            if (env.IsDevelopment())
            {
                configurationBuilder.AddUserSecrets<StartupShared>();
            }

            Configuration = configurationBuilder.Build();
        }
        protected IConfiguration Configuration { get; }
        protected IHostEnvironment Environment { get; set; }

        protected void ConfigureContainer(ContainerBuilder builder)
        {
        }

        protected void ConfigureServices(IServiceCollection services, string[] authScopes = null)
        {
            services
                .AddDbContext(Configuration.GetConnectionString("DefaultConnection"))
                .AddMigrationContext(Configuration.GetConnectionString("DefaultConnection"))
                .AddIdentity<AppUser, AppRole>(opt =>
                {
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    opt.Lockout.MaxFailedAccessAttempts = 5;
                })
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<DataContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

            services.AddJsReport(new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .Configure(cfg => {
                    cfg.TempDirectory = Path.Combine(Directory.GetCurrentDirectory(), "jsreport", "temp");
                    return cfg;
                })
                .AsUtility()
                .Create());

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName, builder =>
                {
                    builder
                        .WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*")
                        .WithExposedHeaders("Content-Disposition");
                });
            });
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddAuth(Configuration);

            services.AddScoped(typeof(TransactionFilter), typeof(TransactionFilter));
            services.AddControllersWithViews(opt => {
                    opt.Filters.AddService<TransactionFilter>(1);
                })
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddResponseCompression();

            services.AddSharedLogic();
        }

        protected void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseFileServer();
            app.UseLocalization();
            app.UseCustomExceptionHandler();
            app.UseCors(_corsPolicyName);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "My API");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallback(async (context) =>
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
                });
            });
        }
    }
}
