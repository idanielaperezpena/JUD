
//Guardar Crédito
$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var CreditoSustentabilidad = $(this).closest('form').serializeObject();
        var titulo = '';
        var titulo2 = '';
        if ($('#CS_IDCreditoSustentabilidad').val() != '') {
            titulo = 'Guardando cambios en el Crédito de Sustentabilidad';
            titulo2 = 'Guardado';
        } else {
            titulo = 'Registrando el Crédito  de Sustentabilidad';
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
            url: "/CreditoSustentabilidad/Insertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ _viewModel: CreditoSustentabilidad }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Crédito de Sustentabilidad ' + titulo2 + 'con éxito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = "/CreditoSustentabilidad";
                    }
                })
            }
        });
    }

});