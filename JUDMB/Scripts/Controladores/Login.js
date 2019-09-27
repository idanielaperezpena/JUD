$(document).ready(function () {
    $('#formulario_login').validate({
        rules:
        {
            No_empleado: { required: true, regex: /^[0-9]{5}$/ },
            Password: { required: true }
        },
        messages:
        {
            No_empleado: { required: "Necesita ingresar su numero de empleado", regex: "El formato no es el correcto" },
            Password: "Necesita ingresar su password"
        },
        errorPlacement: function (error, element) {
            error.appendTo(element.parent("div"));
        }
    });
});


$("#btn_logear").click(function (e) {
    e.preventDefault();
    enviar_formulario();
});


$("#formulario_login").submit(function () {
    e.preventDefault();
    enviar_formulario();
});


function enviar_formulario() {
    if ($('#formulario_login').valid()) {
        var json_form = JSON.stringify($('#formulario_login').serializeObject());
        $.ajax({
            type: "POST",
            url: "/Login/Logear",
            data: json_form,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: mensaje_exito,
            failure: mensaje_mal
        });
    }
}

function mensaje_exito(d) {
    if (d.Error == false) {
        Swal.fire({
            type: 'success',
            title: d.Mensaje
        });
    } else {
        Swal.fire({
            type: 'error',
            title: d.Mensaje,
            text : 'Intente otra vez.'
        });
    }
    console.log(d)
}

function mensaje_mal(d) {
    Swal.fire({
        type: 'error',
        title: 'Ocurrio un error',
        text: 'Intente otra vez.'
    });
    console.log(d)
}
