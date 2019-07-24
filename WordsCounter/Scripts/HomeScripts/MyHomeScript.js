/// DOM betöltődésekor inicializált metódusok/ függvények
$(document).ready(function () {
    /// KeyCode-ok listájának definiálása. Ezekre a billentyűlenyomások
    /// esetén nem hívódik szerveroldali hívás
    var keyCodesArray = [16, 17, 18, 19, 20, 27, 33, 34, 35, 36, 37, 38,
        45, 91, 92, 93, 112, 113, 114, 115, 116, 117, 118, 119, 120,
        121, 122, 123, 144, 145];

    /// Ha a szövegdoboz mezőbe lenyomunk egy gombot, majd felengedjük,
    /// akkor fut le a keresési metódus
    $('#textTextArea').keyup(function (pressedKey) {
        /// Vizsgálat, hogy a lenyomott billentyű érvényes-e!
        if ($.inArray(pressedKey.keyCode, keyCodesArray) != -1) {
            reutrn;
        }

        /// Panelek feltöltése (Ajax hívás)
        getTextResultsAjax($(this).val());
    });
});

/// Az Adatok Törlése gomb Click eseményének definiálása.
/// Kitörli a TextArea-ban található Input adatokat
var deleteTextAreaDatasButtonClick = $(function () {
    $("#deleteTextAreaDatasButton").click(function () {
        /// Input TextArea törlése
        $("#textTextArea").val('');

        /// Panelek feltöltése (Ajax hívás)
        getTextResultsAjax("");
    });
})

/// AJAX hívás. Visszaadja az Output adatokat, az Input adatoknak megfelelően
function getTextResultsAjax(inputText) {
    /// AJAX - Asyncron JavaScript And XML
    $.ajax({
        type: "POST",                               /// Kérés típusa
        url: "../Home/GetAnyInformationFromText",  /// Hol érhető el (Controller/MethodName)
        data: { InputText: inputText },             /// Az adat, amelyet küldünk a Controllernek
        success: function (response) {                 /// Ha sikeresen lefutott az AJAX kérés
            /// A visszatért táblázat törzsét, betöltjük a kész táblázatba
            /// így a keresési eredménynek megfelelően mindig az aktuális adathalmaz
            /// fog megjelenni
            $('#summaryPanel').html(response.summaryInformationInHTMLString);
            openSummaryInformationPanel();
            $('#topWords').html(response.topWordsInHTMLString);
            $('#allWords').html(response.allWordsInHTMLString);
        }
    });
}

/// Kinyitja az összegző információs Panel-t
function openSummaryInformationPanel() {
    document.getElementById('summaryPanel').setAttribute("class", "colpsible-panel collapse in");
    document.getElementById('summaryPanel').setAttribute("aria-expanded", "true");
    document.getElementById('summaryPanel').setAttribute("style", "");
    document.getElementById('summaryPanelHref').setAttribute("class", "colpsible-panel");
    document.getElementById('summaryPanelHref').setAttribute("aria-expanded", "true");
}