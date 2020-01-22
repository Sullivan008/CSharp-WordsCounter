using System.IO;
using System.Web.Mvc;
using WordsCounter.Controllers.Classes.Operations;
using WordsCounter.Models.ViewModels;

namespace WordsCounter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     POST - GetSummaryTextInformation
        ///     Visszaadja, az összegző információkat, a paraméterben kapott
        ///     Input Text-ről
        /// </summary>
        /// <param name="inputText">A vizsgálandó szöveg</param>
        /// <returns>
        ///     JSON objektum amely PartialView-okat tartalmazza - A PartialView-ok tartalmazzák azokat a HTML
        ///     blokkokat, amelyet a SummaryInformation-ban, a TopWords-ben illetve az AllWords Panelekben
        ///     kell elhelyezni.
        /// </returns>
        [HttpPost]
        public JsonResult GetAnyInformationFromText(string inputText)
        {
            NumberOfWordsOperationsViewModel numberOfWordsOperationsViewModel =
                CreateNumberOfWordsOperationsViewModel(new NumbersOfWordsOperations(inputText));

            string summaryInformationInHtmlString =
                RenderRazorViewToString("SummaryInformationPartialView", CreateSummaryInformationViewModel(new SummaryInformationOperations(inputText)));

            string topWordsInHtmlString =
                RenderRazorViewToString("TopWordsPartialView", numberOfWordsOperationsViewModel);

            string allWordsInHtmlString =
                RenderRazorViewToString("AllWordsPartialView", numberOfWordsOperationsViewModel);

            return Json(new
            {
                summaryInformationInHTMLString = summaryInformationInHtmlString,
                topWordsInHTMLString = topWordsInHtmlString,
                allWordsInHTMLString = allWordsInHtmlString
            });
        }

        #region PRIVATE Helper Methods

        /// <summary>
        ///     Elkészít egy SummaryInformationViewModel objektumot, amely tartalmazni fogja
        ///     az összes olyan adatot, amely az összegző információhoz szükséges
        /// </summary>
        /// <param name="summaryInformationOperations">
        ///     Objektum, amely tartalmazza azokat a függvényeket/metódusokat 
        ///     amelyek szükségesek ahhoz, hogy feltöltsük adatokkal a ViewModel-t
        /// </param>
        /// <returns>
        ///     ViewModel objektum amely tartalmazza az összes összegző információhoz szükséges adatot
        /// </returns>
        private SummaryInformationViewModel CreateSummaryInformationViewModel(SummaryInformationOperations summaryInformationOperations)
        {
            return new SummaryInformationViewModel()
            {
                CharactersCount = summaryInformationOperations.GetCharactersCount(),
                CharactersCountWithoutSpaces = summaryInformationOperations.GetCharacterCountsWithoutSpaces(),
                WordsCount = summaryInformationOperations.GetWordsCount(),
                SentencesCount = summaryInformationOperations.GetSentencesCount(),
                ParagraphsCount = summaryInformationOperations.GetParagraphCount(),
                AlphanumericCharactersCount = summaryInformationOperations.GetAlphanumericCharactersCount(),
                NumericCharactersCount = summaryInformationOperations.GetNumericCharactersCount(),
                AlphaCharactersCount = summaryInformationOperations.GetAlphaCharactersCount(),
                UniqueWordsCount = summaryInformationOperations.GetUniqueWordsCount(),
                ShortWordsCount = summaryInformationOperations.GetShortWordsCount(),
                LongWordsCount = summaryInformationOperations.GetLongWordsCount()
            };
        }

        /// <summary>
        ///     Elkészít egy NumberOfWordsOperationsViewModel objektumot, amely tartalmazni fogja
        ///     az összes adatot a szavakhoz tartozó szószámról és szósűrűségről
        /// </summary>
        /// <param name="numbersOfWordsOperations">
        ///     Objektum amely tartalmazza azokat a függvényeket/metódusokat
        ///     amelyek szükségesek ahhoz, hogy feltöltsük adatokkal a ViewModel-t
        /// </param>
        /// <returns>
        ///     ViewModel bojektum amely tartalmazni fogja az összes szóhoz tartozó
        ///     szó előfordulást és szósűrűséget
        /// </returns>
        private NumberOfWordsOperationsViewModel CreateNumberOfWordsOperationsViewModel(NumbersOfWordsOperations numbersOfWordsOperations)
        {
            return new NumberOfWordsOperationsViewModel()
            {
                NumberOfWordsTable = numbersOfWordsOperations.GetNumberOfWordsTable()
            };
        }

        /// <summary>
        ///     Visszaadja egy PartialView eredményét (HTML) String formátumban
        /// </summary>
        /// <param name="viewName">A Partial View neve</param>
        /// <param name="model">Model objektum</param>
        /// <returns>
        ///     A paraméterekben megadott, majd a függvény által elkészített PartialView (HTML)
        ///     string formátumban
        /// </returns>
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;

            using (var stringWriter = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, stringWriter);

                viewResult.View.Render(viewContext, stringWriter);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return stringWriter.GetStringBuilder().ToString();
            }
        }

        #endregion
    }
}