$.validator.addMethod(
    "regex",
    function (value, element, regexp) {
        var re = new RegExp(regexp);
        return this.optional(element) || re.test(value);
    },
    "El formato no es el correcto."
);

$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error');
    }
});

function swal(tipo, titulo, mensaje) {
    Swal.fire({
        type: tipo,
        title: titulo,
        text: mensaje,
    })
}

