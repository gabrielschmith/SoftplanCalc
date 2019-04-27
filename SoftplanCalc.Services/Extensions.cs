using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftplanCalc.Services.CalculateInterest;

namespace SoftplanCalc.Services
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds the calculate interest service.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddCalculateInterest(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new CalculateInterestOptions();
            var section = configuration.GetSection("CalculateInterest");
            section.Bind(options);

            var calculateInterestService = new CalculateInterestService(options);
            services.AddScoped<ICalculateInterestService>(_ => calculateInterestService);
        }
    }
}
