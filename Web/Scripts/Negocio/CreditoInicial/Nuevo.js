
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

//Cargar vistas parciales
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

$(document).on('change',"#CIU_IDEstadoCivil", function (e) {
    var val = $(this).val();
    if (val == 1 || val == 8) {
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetParejaViewModel",
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

$(document).on('change',"#DiferenteDomicilio",function (e) {
    if ($(this).is(":checked")) {
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetDomicilioViewModel",
            success: function (e) {
                $('#DomicilioViewModel').html(e);
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }
        });
    } else {
        $('#DomicilioViewModel').html("");
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    }
});

$(document).on('change', "#DiferenteDomicilio", function (e) {
    if ($(this).is(":checked")) {
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetDomicilioViewModel",
            success: function (e) {
                $('#DomicilioViewModel').html(e);
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }
        });
    } else {
        $('#DomicilioViewModel').html("");
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    }
});

$(document).on('change', "input[name=RequiereDS]", function (e) {
    if ($('input[name=RequiereDS]:checked').val() == 1) {
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetDeudorSolidarioViewModel",
            success: function (e) {
                $('#DeudorSolidarioViewModel').html(e);
                $("form").each(function () { $.data($(this)[0], 'validator', false); });
                $.validator.unobtrusive.parse("form");
            }
        });
    } else {
        $('#DeudorSolidarioViewModel').html("");
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    }
});

//Guardar CI con ciudadano Insertado
$(document).on('click', '#guardar', function (e) {
    e.preventDefault();
    if ($(this).closest('form').valid()) {
        var CreditoInicial = $(this).closest('form').serializeObject();
        var Ciudadano = $(this).closest('form').serializeObject();
        var Pareja = $('#ParejaViewModel').find('select, textarea, input').serializeObject();
        var Domicilio_Diferente = $('#DomicilioViewModel').find('select, textarea, input').serializeObject();
        var Deudor_Solidario = $('#DeudorSolidarioViewModel').find('select, textarea, input').serializeObject();
        CreditoInicial.CiudadanoInsertar = Ciudadano;
        CreditoInicial.CiudadanoInsertar.Pareja = Pareja;
        CreditoInicial.CiudadanoInsertar.Domicilio_Diferente = Domicilio_Diferente;
        CreditoInicial.CiudadanoInsertar.DeudorSolidario = Deudor_Solidario;
        console.log(CreditoInicial);
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/Insertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ viewModel: CreditoInicial }),
            success: function (e) {
                console.log(e)
            }
        });
    }
    
});


//GUardar CI con nuevo ciudadano

//Funcionamiento siguiente anterior
$(document).on('click', '.siguiente', function (e) {
    if ($(this).closest('form').valid()) {
        var step = $(this).attr('data-step');
        $(this).closest('fieldset').slideUp('slow');
        $('#step' + step).slideDown('slow');
    }
});