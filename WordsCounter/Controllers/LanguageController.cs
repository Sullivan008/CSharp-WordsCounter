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
        /// <param name="LanguageAbbrevation">A kiválasztott nyelvi kód (HU, EN, stb...)</param>
        /// <returns>Az aktuális oldal újrafrissítése</returns>
        [HttpGet]
        public ActionResult Change(string LanguageAbbrevation)
        {
            /// Vizsgálat, hogy a GET-ben kapott paraméter-nek van e értéke, ha igen, akkor...
            if (LanguageAbbrevation != null)
            {
                /// A nyelvi elemek beállítása az adott szálon futó webalkalmazásnak
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }

            /// Language Cookie elkészítése, majd értékének beállítása a GET
            /// által kapott paramterű nyelvi kóddal
            HttpCookie cookie = new HttpCookie("Language")
            {
                Value = LanguageAbbrevation
            };

            /// Az elkészített Cookie hozzáadása a Response-hoz
            Response.Cookies.Add(cookie);

            /// Jelenlegi oldal frissítése
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}