using System;
using Microsoft.Extensions.Configuration;

namespace SoftplanCalc.Api.Tests
{
    /// <summary>
    /// Test helper.
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// Gets the IC onfiguration.
        /// </summary>
        /// <returns>The IC onfiguration.</returns>
        /// <param name="outputPath">Output path.</param>
        public static IConfiguration GetIConfiguration(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
