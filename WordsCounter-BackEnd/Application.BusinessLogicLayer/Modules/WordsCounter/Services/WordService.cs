using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Application.BusinessLogicLayer.Modules.WordsCounter.Services.Interfaces;

namespace Application.BusinessLogicLayer.Modules.WordsCounter.Services
{
    public class WordService : IWordService
    {
        public IEnumerable<string> GetWords(string text)
        {
            Regex pattern = new(pattern: @"[^\W](\w|[-']{1,2}(?=\w))*", RegexOptions.IgnorePatternWhitespace);

            return pattern.Matches(text).Select(x => x.Value);
        }
    }
}
