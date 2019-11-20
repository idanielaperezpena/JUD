
//Guardar Dictamen 
$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var ModificacionesCredito = $(this).closest('form').serializeObject();
        var titulo = '';
        var titulo2 = '';
        if ($('#MC_IDModificacionesCredito').val() != '') {
            titulo = 'Guardando cambios en la Solicitud';
            titulo2 = 'Guardado';
        } else {
            titulo = 'Registrando la Solicitud';
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
            url: "/ModificacionesCredito/Insertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ _viewModel: ModificacionesCredito }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Modificaciones al Crédito ' + titulo2 + ' con éxito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = "/ModificacionesCredito";
                    }
                })
            }
        });
    }

});