
//Guardar Dictamen 
$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var DictamenJuridico = $(this).closest('form').serializeObject();
        var titulo = '';
        var titulo2 = '';
        if ($('#IDDictamenJuridico').val() != '') {
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
            url: "/Dictamenes/InsertarDictamenJuridico",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ viewModel: DictamenJuridico }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Dictamen ' + titulo2+' con exito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = "/CreditoInicial";
                    }
                })
            }
        });
    }
    
});

