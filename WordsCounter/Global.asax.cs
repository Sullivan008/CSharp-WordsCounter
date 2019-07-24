using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WordsCounter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string DEFAULT_LANGUAGE = "EN";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /// X-AspNetMvc-Version elrejtése
            MvcHandler.DisableMvcResponseHeader = true;
        }

        /// <summary>
        ///     Esemény, amely minden Request előtt lefut.
        /// </summary>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            /// A Language Cookie-hoz tartozó érték kiolvasása
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];

            /// Vizsgálat, hogy a Cookie-kban található-e már korábbi nyelvi kód,
            /// azaz választottunk-e már korábban nyelvet, ha igen, akkor...
            if (cookie != null && cookie.Value != null)
            {
                /// A nyelvi elemek beállítása az adott szálon futó webalkalmazásnak
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                /// A default nyelvi elemek beállítása az adott szálon futó webalkalmazásnak
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(DEFAULT_LANGUAGE);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(DEFAULT_LANGUAGE);
            }

            /// X-FRAME-Options (Clickjacking Hack elleni védelem)
            HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");
        }
    }
}
