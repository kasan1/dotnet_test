using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agro.Shared.Api;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Agro.Admin.Api
{
    public class Startup : StartupShared
    {
        public Startup(IConfiguration configuration, IHostEnvironment hosting) : base(configuration, hosting)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
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
