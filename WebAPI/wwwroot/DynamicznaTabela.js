var rows = 3;

function deleteRow(clickedElement) {
    console.log(clickedElement);
    row = clickedElement.parent().parent();
    console.log(row);
    row.remove();
}


$(document).ready(function () {
    $("#dodaj").click(function () {
        var imie = $("#imie").val();
        var nazw = $("#nazw").val();
        var wiek = $("#wiek").val();
        var trI = $("<td>").html(imie);
        var trN = $("<td>").html(nazw);
        var trW = $("<td>").html(wiek);
        var mBtn = $("<button>").html("-");
        var row = $("<tr>");
        var trB = $("<td>").append(mBtn);
        row.append(trI).append(trN).append(trW).append(trB);
        $("#tabelka").append(row);
        console.log(row);
        mBtn.on("click", function (event) {
            deleteRow($(event.target));
        });
    });

    $(".minus").on("click",function (event) {
        var btn = $(event.target);//btn = $(this);
        deleteRow(btn);
    })
})