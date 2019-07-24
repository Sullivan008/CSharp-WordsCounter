using System;
using System.Collections.Generic;

namespace WordsCounter.Models.ViewModels
{
    public class NumberOfWordsOperationsViewModel
    {
        /// Tárolja az egyedi szavak számát, szósűrűséggel együtt
        public List<KeyValuePair<string, Tuple<int, double>>> NumberOfWordsTable;
    }
}