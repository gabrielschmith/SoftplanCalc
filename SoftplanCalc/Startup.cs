using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using SoftplanCalc.Logger;
using SoftplanCalc.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SoftplanCalc.Api
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures the services.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogger();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCalculateInterest(Configuration);

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new Info
                {
                    Title = "Softplan Calculation Api.",
                    Version = "v1",
                    Description = "Softplan Calculation Api Rest with ASP.NET Core",
                    Contact = new Contact
                    {
                        Name = "Gabriel Schmith",
                        Url = "https://github.com/gabrielschmith"
                    }
                });

                string pathApp = PlatformServices.Default.Application.ApplicationBasePath;
                string nameApp = PlatformServices.Default.Application.ApplicationName;
                string pathXmlDoc = Path.Combine(pathApp, $"{nameApp}.xml");

                sw.IncludeXmlComments(pathXmlDoc);
            });
        }

        /// <summary>
        /// Configure the specified app and env.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Softplan Calculation Api");
            });
        }
    }
}
