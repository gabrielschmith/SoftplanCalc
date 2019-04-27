using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace SoftplanCalc.Logger
{
    public static class Extensions
    {
        /// <summary>
        /// Adds the logger.
        /// </summary>
        /// <returns>The logger.</returns>
        /// <param name="services">Services.</param>
        public static void AddLogger(this IServiceCollection services)
        {
            services.AddSingleton<IBaseLogger, BaseLogger>();
        }

        /// <summary>
        /// Uses the logger.
        /// </summary>
        /// <returns>The logger.</returns>
        /// <param name="builder">Builder.</param>
        /// <param name="configuration">Configuration.</param>
        public static IWebHostBuilder UseLogger(this IWebHostBuilder builder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration)
                .CreateLogger();

            return builder.UseSerilog();
        }
    }
}
