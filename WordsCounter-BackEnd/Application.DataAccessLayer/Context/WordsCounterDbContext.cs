using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.Context
{
    public class WordsCounterDbContext : DbContext
    {
        public WordsCounterDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WordsCounterDbContext).Assembly);
        }

        #region DbSets
            
        

        #endregion
    }
}
