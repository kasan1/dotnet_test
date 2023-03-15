using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Interfaces;
using Agro.Shared.Logic.Common.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Agro.Shared.Api.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString, IsolationLevel level = IsolationLevel.ReadUncommitted)            
        {
            services.AddScoped<DbConnection>(serviceProvider =>
            {
                var dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
                return dbConnection;
            });

            services.AddScoped<DbTransaction>(serviceProvider =>
            {
                var dbConnection = serviceProvider.GetRequiredService<DbConnection>();

                return dbConnection.BeginTransaction(level);
            });

            services.AddScoped<DbContextOptions<DataContext>>(serviceProvider =>
            {
                var dbConnection = serviceProvider.GetRequiredService<DbConnection>();

                return new DbContextOptionsBuilder<DataContext>()
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(dbConnection)
                    .Options;
            });

            services.AddScoped<DataContext>(serviceProvider =>
            {
                var transaction = serviceProvider.GetRequiredService<DbTransaction>();
                var options = serviceProvider.GetRequiredService<DbContextOptions<DataContext>>();
                var context = new DataContext(options);
                context.Database.UseTransaction(transaction);
                return context;
            });

            return services;
        }

        public static IServiceCollection AddMigrationContext(this IServiceCollection services, string connectionString)
        {
            return services.AddScoped<IMigrationContext>(serviceProvider =>
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(connectionString)
                    .Options;

                return new DataContext(options);
            });
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            configuration.Bind(nameof(JwtOptions), jwtOptions);
            services.AddSingleton(jwtOptions);

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                ValidateIssuer = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = false,
            };
            services.AddSingleton(tokenValidationParameters);

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = tokenValidationParameters;
                    opt.SaveToken = true;

                    opt.Events = new JwtBearerEvents() // Only for angular application
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {                                
                                context.Response.Headers.Add("X-Token-Expired", "true");
                                context.Response.Headers.Add("Access-Control-Expose-Headers", "X-Token-Expired");
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }
    }
}
