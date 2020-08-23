$(document).ready(function () {
    $("#Phone").inputmask("mask", { "mask": "(99) 9999-99999" });
    $("#CPF").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
    $("#ZipCode").inputmask("mask", { "mask": "99999-999" });
});