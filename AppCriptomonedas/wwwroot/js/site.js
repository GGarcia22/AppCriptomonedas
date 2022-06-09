// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('submit', '@ingreso', function (e) {
    e.preventDefault();
    $.ajax({
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            window.location = '/Ingreso';
        },
        error: function () {
            $('.alert').show();
            $('.alert').text('El usuario o contraseña no es valido!');
        }
    });
});
$('.campo').val("");
var val1 = $("table tr:last").find("#IdRetiro").html();
if (val1 >= 1) {
    $(".url".attr("href", "/Retiros/Edit/" + $.trim(val1)));
} else {
    $(".url").attr("href", "/Retiros/Create/");
}
