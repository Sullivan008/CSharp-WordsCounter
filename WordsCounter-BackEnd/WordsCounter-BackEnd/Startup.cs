using Application.DataAccessLayer.Context;
using Application.Web.Core.Configurations;
using Application.Web.Core.Extensions;
using Application.Web.Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WordsCounterDbContext>(options =>
                options.UseSqlServer(
                    _configuration.GetConnectionString("DevConnection")
                )
            );

            services.ConfigureReadOnlyDbContext();
            services.ConfigureMediatR();

            services.ConfigureSwaggerServices();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider, IWebHostEnvironment env)
        {
            app.AddGlobalErrorHandlerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureSwagger(provider);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
