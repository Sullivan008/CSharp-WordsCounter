using System.Linq;
using Application.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.Context
{
    public class WordsCounterReadOnlyDbContext
    {
        private readonly WordsCounterDbContext _context;

        public WordsCounterReadOnlyDbContext(WordsCounterDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationLog> ApplicationLogs => _context.ApplicationLog.AsNoTracking();
    }
}
