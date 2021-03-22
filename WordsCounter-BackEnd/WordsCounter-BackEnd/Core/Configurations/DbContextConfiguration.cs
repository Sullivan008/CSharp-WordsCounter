using Application.DataAccessLayer.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Web.Core.Configurations
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection ConfigureReadOnlyDbContext(this IServiceCollection services)
        {
            services.AddScoped<WordsCounterReadOnlyDbContext>();

            return services;
        }
    }
}
