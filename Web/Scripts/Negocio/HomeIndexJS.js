
$("form").submit(function () {
    e.preventDefault();
    enviar_formulario();
});

$("#btn_logear").click(function (e) {
    e.preventDefault();
    enviar_formulario();
});

function enviar_formulario() {
    if ($('form').valid()) {
        var json_form = $('form').serialize();
        $.ajax({
            type: "POST",
            url: "/Home/Index",
            data: json_form,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: "json",
            success: mensaje_exito,
            failure: mensaje_mal
        });
    }
}

function mensaje_exito(d) {
    console.log(d);
    if (d == "exito") {
        Swal.fire({
            type: 'success',
            title: d.Mensaje,
            onClose: function () {
                window.location = "/Principal";
            }
        });
    } else {
        Swal.fire({
            type: 'error',
            title: d.Mensaje,
            text: 'Intente otra vez.'
        });
    }
}

function mensaje_mal(d) {
    Swal.fire({
        type: 'error',
        title: 'Ocurrio un error',
        text: 'Intente otra vez.'
    });
}
