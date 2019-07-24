using System.Collections.Generic;
using System.Web.Mvc;

namespace WordsCounter.Controllers.Classes.Dictionary
{
    public class LanguageDictionary
    {
        /// <summary>
        ///     Egy nyelvi kódokból álló SelectListItem listát definiál
        /// </summary>
        /// <returns>
        ///     HashSet amely SelectListItem típusú nyelvi kód objektumokat tartalmaz
        /// </returns>
        public HashSet<SelectListItem> GetLanguageSelectListItem()
        {
            return (new HashSet<SelectListItem>
            {
                new SelectListItem { Text = "EN", Value = "0"},
                new SelectListItem { Text = "HU", Value = "1"}
            });
        }
    }
}