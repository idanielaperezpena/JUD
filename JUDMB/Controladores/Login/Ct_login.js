

$(document).ready(function () {
    $('#formulario').validate({
        rules:
        {
            no_empleado: { required: true, regex: /^[0-9]{5}$/ },
            password: { required : true}
        },
        messages:
        {
            no_empleado: { required: "Necesita ingresar su numero de empleado", regex: "El formato no es el correcto" },
            password : "Necesita ingresar su password"
        },
        errorPlacement: function (error, element) {
            error.appendTo(element.parent("div"));
        }
    });

    $('input').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
        increaseArea: '20%' /* optional */
    });
});


$("#btn_logear").click(function (e) {
    e.preventDefault();
    enviar_formulario(); 
});


$("#formulario").submit(function () {
    e.preventDefault();
    enviar_formulario();
});

function enviar_formulario() {
    if ($('#formulario').valid()) {
        var no_empleado = $("#no_empleado").val();
        var password = $("#password").val();
        $.ajax({
            type: "POST",
            url: "Login.aspx/validar",
            data: '{ "no_empleado": ' + no_empleado + ', "password": ' + password + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: mensaje_exito,
            failure: mensaje_mal
        });
    }
}


function mensaje_exito(response) {
    if (response.d[1] == 'error' ) {
        swal('error', 'Datos erroneos', 'Vuelve a intentarlo');
    } else {
        Swal.fire({
            type: 'success',
            title: 'Datos Correctos',
            text: 'Bienvenido!!',
            onAfterClose:() => {
                console.log("xd");
            }
        })
    }

}

function mensaje_mal(response) {
    alert(response.d);
}

