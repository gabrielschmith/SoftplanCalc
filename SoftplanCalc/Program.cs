using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SoftplanCalc.Logger;

namespace SoftplanCalc.Api
{
    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <returns>The web host builder.</returns>
        /// <param name="args">Arguments.</param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            Console.Title = $"Softplan Api: {typeof(Startup).Namespace} - Version: {typeof(Startup).Assembly.GetName().Version}";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                })
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseConfiguration(config)
                .UseLogger(config)
                .UseStartup<Startup>();

            return webHostBuilder;
        }
    }
}
