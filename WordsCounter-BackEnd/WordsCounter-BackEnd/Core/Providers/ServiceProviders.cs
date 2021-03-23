using Application.BusinessLogicLayer.Modules.WordsCounter.Services;
using Application.BusinessLogicLayer.Modules.WordsCounter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Web.Core.Providers
{
    public static class ServiceProviders
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IWordService, WordService>();

            return services;
        }
    }
}
