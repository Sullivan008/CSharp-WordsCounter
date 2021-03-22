using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.Extensions
{
    public static class WordsCounterDbContextExtension
    {
        public static async Task InitDatabase(this WordsCounterDbContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
