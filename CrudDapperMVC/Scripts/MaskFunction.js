$(document).ready(function () {
    $("#Phone").inputmask("mask", { "mask": "(99) 9999-99999" });
    $("#User_Phone").inputmask("mask", { "mask": "(99) 9999-99999" });
    $("#CPF").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
    $("#CNPJ").inputmask("mask", { "mask": "99.999.999/9999-99" }, { reverse: true });
    $("#Address_Zip").inputmask("mask", { "mask": "99999-999" });
    $("#nascimento").inputmask("mask", { "mask": "99/99/9999" });
    $("#preco").inputmask("mask", { "mask": "999.999,99" }, { reverse: true });
    $("#Cellphone").inputmask("mask", { "mask": "(99) 99999-9999" }, { reverse: false });
    $("#ip").inputmask("mask", { "mask": "999.999.999.999" });
    $("#ip").inputmask("mask", { "mask": "999.999.999.999" });
});