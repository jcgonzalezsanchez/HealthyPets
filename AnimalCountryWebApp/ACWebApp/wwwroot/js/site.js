// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    $('.sidenav').sidenav();
    $('.datepicker').datepicker({
        yearRange: [2000, 2020],
        format: 'dd/mm/yyyy'
    });
    $('select').formSelect(),
        $('.carousel.carousel-slider').carousel({
            fullWidth: true
        });
});