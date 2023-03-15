using System.Collections.Generic;
using System.Reflection;
using Agro.Shared.Data.Repos.OutService;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Logic.Common.Behaviours;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.OutService.PKB;
using Agro.Shared.Logic.Scoring;
using Agro.Shared.Logic.Services.ClientDetails;
using Agro.Shared.Logic.Services.Sender;
using Agro.Shared.Logic.Services.System.File;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Logic.Services.System.User.Branch;
using Agro.Shared.Logic.Services.System.User.Identity;
using Agro.Shared.Logic.Services.System.User.Profile;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Agro.Shared.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedLogic(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IUserBranchService, UserBranchService>();

            services.AddTransient<LocalFileService>();
            services.AddTransient<DatabaseFileService>();
            services.AddTransient<Delegates.FileServiceResolver>(serviceProvider => key =>
            {
                return key switch
                {
                    FileServiceTypeEnum.Local => serviceProvider.GetRequiredService<LocalFileService>(),
                    FileServiceTypeEnum.Database => serviceProvider.GetRequiredService<DatabaseFileService>(),
                    _ => throw new KeyNotFoundException(),
                };
            });

            services.AddTransient<ISenderService, EmailSenderService>();

            services.AddTransient<IProcessLogic, ProcessLogic>();
            services.AddTransient<IPKBLogic, PKBLogic>();
            services.AddTransient<IPKBChecksLogic, PKBChecksLogic>();
            services.AddTransient<IClientDetailsService, ClientDetailsService>();
            services.AddTransient<IOutServiceRepo, OutServiceRepo>();

            return services;
        }
    }
}
