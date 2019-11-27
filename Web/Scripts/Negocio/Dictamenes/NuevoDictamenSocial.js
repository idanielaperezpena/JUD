
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

$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var DictamenSocial = $(this).closest('form').serializeObject();
        var titulo = '';
        var titulo2 = '';
        if ($('#IDDictamenSocial').val() != '') {
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
            url: "/Dictamenes/InsertarDictamenSocial",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ _viewModel: DictamenSocial }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Dictamen ' + titulo2 + ' con éxito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = redireccion;
                    }
                })
            }
        });
    }

});