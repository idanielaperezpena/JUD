

//Guardar Dictamen 
var tipo_credito;
var redireccion;
$(document).ready(function () {
    tipo_credito = $("#TipoCredito").val();
    switch (tipo_credito) {
        case "CI":
            redireccion = "/CreditoInicial";
            break;
        case "CC":
            redireccion = "/CreditoComplementario";
            break;
        case "CS":
            redireccion = "/CreditoSustentabilidad";
            break;
        case "MC":
            redireccion = "/ModificacionesCredito";
            break;
    }
});

//Guardar Dictamen 
$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var DictamenTecnico = $(this).closest('form').serializeObject();
        var titulo = '';
        var titulo2 = '';
        if ($('#IDDictamenTecnico').val() != '') {
            titulo = 'Guardando cambios en el dictamen';
            titulo2 = 'Guardado';
        } else {
            titulo = 'Registrando el dictamen';
            titulo2 = 'Registrado';
        }

        Swal.fire({
            title: titulo,
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
            }
        })

        $.ajax({
            type: "POST",
            url: "/Dictamenes/InsertarDictamenTecnico",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ _viewModel: DictamenTecnico }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Dictamen ' + titulo2 + ' con exito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = redireccion;
                    }
                })
            }
        });
    }

});