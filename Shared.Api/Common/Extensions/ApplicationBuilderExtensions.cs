using Agro.Shared.Api.Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace Agro.Shared.Api.Common.Extensions
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/> extensions
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        #region Fields

        private static readonly RequestCulture _defaultRequestCulture = new RequestCulture("ru");

        private static readonly List<CultureInfo> _supportedCultures = new List<CultureInfo> {
                    //new CultureInfo("en"),
                    new CultureInfo("ru"),
                    new CultureInfo("kk")
                };

        #endregion

        #region Public functions

        /// <summary>
        /// Adds request localization middleware
        /// </summary>
        /// <param name="applicationBuilder">Application request pipeline builder</param>
        /// <returns>Application request pipeline builder</returns>
        public static IApplicationBuilder UseLocalization(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseRequestLocalization(opt =>
                {
                    opt.DefaultRequestCulture = _defaultRequestCulture;
                    opt.SupportedCultures = _supportedCultures;
                    opt.SupportedUICultures = _supportedCultures;
                });
        }

        /// <summary>
        /// Adds custom exception handler middleware
        /// </summary>
        /// <param name="applicationBuilder">Application request pipeline builder</param>
        /// <returns>Application request pipeline builder</returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }

        #endregion
    }
}
