using AutoMapper;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agro.Okaps.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOkapsLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
