// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#myBtn3").click(function () {
        $("#myModal3").modal();
    });
    $("#myBtn2").click(function () {
        $("#myModal2").modal();
    });
    $("#myBtn1").click(function () {
        $("#myModal1").modal();
    });
});
$('#multi1').mdbRange({
    single: {
        active: true
    }
});