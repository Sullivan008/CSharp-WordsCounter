$(document).ready(function () {
    $("#Languages").change(function () {
        var selectedLanguage = $("#Languages option:selected").text();

        $.ajax({
            type: "GET",
            url: "/Language/Change?languageAbbreviation=" + selectedLanguage,
            success: function () {
                location.reload();
            }
        });
    });
})