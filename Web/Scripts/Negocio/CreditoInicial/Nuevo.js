
// Buscar Ciudadano
$("#btn_Buscar").click(function (e) {
    e.preventDefault();
    if ($('#CadenaBusqueda').valid()) {
        var CadenaBusqueda = $('#CadenaBusqueda').val();
        $.ajax({
            type: "POST",
            url: "/Ciudadano/BusquedaExistente",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ CadenaBusqueda: CadenaBusqueda }),
            success: function (e) {
                $('#tabla_ciudadanos').html(e)
            }
        });
    }
});

$(document).on('click', '#tabla_ciudadano tbody > tr', function (e) {
    e.preventDefault();
    if ($(this).attr('class') !== 'empty-container') {
        var IDCiudadano = $(this).attr('id');
        Swal.fire({
            title: 'Cargando los datos del Ciudadano',
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
            }
        })
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetCiudadanoInsertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ ID: IDCiudadano }),
            success: function (e) {
                $('#div_buscar_ciudadano').slideUp();
                $('form').append(e);
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
                Swal.close();
            }
        });
    }
    
});

$("#nuevo_ciudadano").click(function (e) {
    e.preventDefault();
    Swal.fire({
        title: 'Cargando Formulario del ciudadano',
        allowOutsideClick: false,
        onBeforeOpen: () => {
            Swal.showLoading()
        }
    })
    $.ajax({
        type: "POST",
        url: "/CreditoInicial/GetCiudadanoInsertar",
        contentType: "application/json; charset=utf-8",
        success: function (e) {
            $('#div_buscar_ciudadano').slideUp();
            $('form').append(e);
            $("form").each(function () { $.data($(this)[0], 'validator', false); });
            $.validator.unobtrusive.parse("form");
            Swal.close();
        }
    });
});

$(document).on('click', '.siguiente', function (e) {
    if ($(this).closest('form').valid()) {
        var step = $(this).attr('data-step');
        $(this).closest('fieldset').slideUp('slow');
        $('#step' + step).slideDown('slow');
    }
});