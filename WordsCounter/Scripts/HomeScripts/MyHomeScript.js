$(document).ready(function () {
    var keyCodesArray = [16, 17, 18, 19, 20, 27, 33, 34, 35, 36, 37, 38,
        45, 91, 92, 93, 112, 113, 114, 115, 116, 117, 118, 119, 120,
        121, 122, 123, 144, 145];

    $('#textTextArea').keyup(function (pressedKey) {
        if ($.inArray(pressedKey.keyCode, keyCodesArray) !== -1) {
            return;
        }

        getTextResultsAjax($(this).val());
    });
});

var deleteTextAreaDatasButtonClick = $(function () {
    $("#deleteTextAreaDatasButton").click(function () {
        $("#textTextArea").val("");

        getTextResultsAjax("");
    });
});

function getTextResultsAjax(inputText) {
    $.ajax({
        type: "POST",
        url: "../Home/GetAnyInformationFromText",
        data: { inputText: inputText },
        success: function (response) {
            $("#summaryPanel").html(response.summaryInformationInHTMLString);

            openSummaryInformationPanel();

            $("#topWords").html(response.topWordsInHTMLString);
            $("#allWords").html(response.allWordsInHTMLString);
        }
    });
}

function openSummaryInformationPanel() {
    document.getElementById("summaryPanel").setAttribute("class", "colpsible-panel collapse in");
    document.getElementById("summaryPanel").setAttribute("aria-expanded", "true");
    document.getElementById("summaryPanel").setAttribute("style", "");
    document.getElementById("summaryPanelHref").setAttribute("class", "colpsible-panel");
    document.getElementById("summaryPanelHref").setAttribute("aria-expanded", "true");
}