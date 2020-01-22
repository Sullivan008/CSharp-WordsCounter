using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WordsCounter.Controllers
{
    public class LanguageController : Controller
    {
        /// <summary>
        ///     A webalkalmazás nyelvének megváltoztatásááért felelős metódus
        /// </summary>
        /// <param name="languageAbbreviation">A kiválasztott nyelvi kód (HU, EN, stb...)</param>
        [HttpGet]
        public ActionResult Change(string languageAbbreviation)
        {
            if (languageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageAbbreviation);
            }

            HttpCookie cookie = new HttpCookie("Language")
            {
                Value = languageAbbreviation
            };

            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer?.ToString());
        }
    }
}