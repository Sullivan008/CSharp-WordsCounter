/// Ha a DOM teljesen betöltött, akkor...
$(document).ready(function () {
    /// Az Nyelv választó DropDownList-ben található elem kiválasztásakor
    /// fusson le a metódus. A metódus eredménye, hogy az oldal, a kiválasztott
    /// nyelven fog megjelenni
    $('#Languages').change(function () {

        /// A nyelv listában kiválasztott elem szöveges értéke (Language Text)
        var selectedLanguage = $("#Languages option:selected").text();

        /// AJAX - Asyncron JavaScript And XML
        $.ajax({
            type: "GET",                                                        /// Kérés típusa
            url: "/Language/Change?LanguageAbbrevation=" + selectedLanguage,   /// Hol érhető el (Controller/MethodName)
            success: function () {                                                 /// Ha skeresen lefutott az AJAX kérés
                /// Az aktuális oldal újratöltése
                location.reload();
            }
        })
    })
})