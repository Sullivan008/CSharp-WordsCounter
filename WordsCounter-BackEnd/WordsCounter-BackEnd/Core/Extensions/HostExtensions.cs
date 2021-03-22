using System;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Web.Core.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider serviceProvider = scope.ServiceProvider;

                WordsCounterDbContext context = serviceProvider.GetRequiredService<WordsCounterDbContext>();

                context.InitDatabase().Wait();
            }

            return host;
        }
    }
}
