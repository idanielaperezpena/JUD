//guardar ciudadano
$(document).on('click', '#guardar', function (e) {
    alert('hola');
   
    e.preventDefault();
    if ($(this).closest('form').valid())
    {
        alert('dentro if despues de ciudadano');
        var Ciudadano = $(this).closest('form').serializeObject();
        var Pareja = $('#ParejaViewModel').find('select, textarea, input').serializeObject();
        var Domicilio_Trabajo = $('#DomicilioTrabajoViewModel').find('select, textarea, input').serializeObject();
        var Deudor_Solidario = $('#DeudorSolidarioViewModel').find('select, textarea, input').serializeObject();
        Ciudadano.Pareja = Pareja;
        Ciudadano.Domicilio_Trabajo = Domicilio_Trabajo;
        Ciudadano.DeudorSolidario = Deudor_Solidario;
        alert('dentro if despues de ciudadano');
        alert(JSON.stringify({ viewModel: Ciudadano }));
        Swal.fire({
            title: 'Registrando al Ciudadano',
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
            }
        })
        $.ajax({
            type: "POST",
            url: "/Ciudadano/Insertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ viewModel: Ciudadano }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Ciudadano registrado con exito',
                    allowOutsideClick: false,
                    onClose: () => {
                        window.location = "/Ciudadano";
                    }
                })
            }
        });
    }

});

$(document).on('change', "#CIU_IDEstadoCivil", function (e) {
    var val = $(this).val();
    if (val == 1 || val == 8) {
        $.ajax({
            type: "POST",
            url: "/Ciudadano/GetParejaViewModel",
            success: function (e) {
                $('#ParejaViewModel').html(e);
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }
        });
    } else {
        $('#ParejaViewModel').html("");
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    }
});
$(document).on('change', "#CIU_IDOcupacion", function (e) {
    var val = $(this).val();
    if (val == 1 || val == 2) {
        $.ajax({
            type: "POST",
            url: "/Ciudadano/GetDomicilioViewModel",
            success: function (e) {
                $('#DomicilioTrabajoViewModel').html(e);
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }
        });
    } else {
        $('#DomicilioTrabajoViewModel').html("");
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    }
});


$('.siguiente').click(function (e) {
    var step = $(this).attr('data-step');
    $(this).closest('fieldset').slideUp('slow');
    $('#step' + step).slideDown('slow');
});