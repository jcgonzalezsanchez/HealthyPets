// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//$(document).ready(function () {
//    $('.sidenav').sidenav();
//    $('.datepicker').datepicker({
//        yearRange: [2000, 2020],
//        format: 'dd/mm/yyyy'
//    });

$(document).ready(function () {
    $('#datepicker').datepicker({
        uiLibrary: 'bootstrap4',
        autoclose: true,
        todayBtn: true
    });
});



//Search

$("#txtsearch").on("keyup", function () {
    var validChars = "0123456789";
    var txtenter = $(this).val().toString();
    $("table tr").each(function (results) {
        if (results !== 0) {
            var id = $(this).find("td:nth-child(2)").text();
            var id2 = $(this).find("td:nth-child(1)").text();
            if (id.indexOf(txtenter) !== 0 && id.toLowerCase().indexOf(txtenter.toLowerCase()) < 0 &&
                id2.indexOf(txtenter) !== 0 && id2.toLowerCase().indexOf(txtenter.toLowerCase()) < 0) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        }
    });
});
