// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.date').mask('00/00/0000');
    $('.phone_br').focusout(function () {
        var phone, element;
        element = $(this);
        element.unmask();
        phone = element.val().replace(/\D/g, '');
        if (phone.length > 10) {
            element.mask("(99) 99999-9999");
        } else {
            element.mask("(99) 9999-99999");
        }
    }).trigger('focusout');
    $('.cep').mask('00000-000');
    $('.cpf').mask('000.000.000-00', {reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', {reverse: true });
    $('.rg').mask('00.000.000-0', {reverse: true });
});

