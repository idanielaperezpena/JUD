
//Guardar Dictamen 
$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var CreditoComplementario = $(this).closest('form').serializeObject();
        var titulo = '';
        var titulo2 = '';
        if ($('#CC_IDCreditoComplementario').val() != '') {
            titulo = 'Guardando cambios en el Crédito Complementario';
            titulo2 = 'Guardado';
        } else {
            titulo = 'Registrando el Crédito Complementario';
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
            url: "/CreditoComplementario/Insertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ _viewModel: CreditoComplementario }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Crédito Complementario ' + titulo2 + 'con éxito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = "/CreditoComplementario";
                    }
                })
            }
        });
    }

});