namespace Application.DataAccessLayer.Context
{
    public class WordsCounterReadOnlyDbContext
    {
        private readonly WordsCounterDbContext _context;

        public WordsCounterReadOnlyDbContext(WordsCounterDbContext context)
        {
            _context = context;
        }
    }
}
