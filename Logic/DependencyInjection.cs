using Agro.Bpm.Logic.Common.Extensions;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agro.Bpm.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBpmLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSharedServices(configuration);
            services.AddCamundaService();
            return services;
        }
    }
}
