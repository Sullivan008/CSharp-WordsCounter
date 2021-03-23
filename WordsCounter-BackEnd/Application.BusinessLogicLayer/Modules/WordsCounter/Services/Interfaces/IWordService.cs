using System.Collections.Generic;

namespace Application.BusinessLogicLayer.Modules.WordsCounter.Services.Interfaces
{
    public interface IWordService
    {
        IEnumerable<string> GetWords(string text);
    }
}
