
// Cargar Vistar Parciales
$("#CIU_IDEstadoCivil").change(function (e) {
    var val = $(this).val();
    if (val == 1 || val == 8) {
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetParejaViewModel",
            success: function (e) {
                $('#ParejaViewModel').html(e);
            }
        });
    } else {
        $('#ParejaViewModel').html("");
        var form = $("form");
        form.removeData('validator');
        form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse(form);
    }
});

$("#DiferenteDomicilio").change(function (e) {
    if ($(this).is(":checked")) {
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/GetDomicilioViewModel",
            success: function (e) {
                $('#DomicilioViewModel').html(e);
            }
        });
    } else {
        $('#DomicilioViewModel').html("");
        var form = $("form");
        form.removeData('validator');
        form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse(form);
    }
});



$('.siguiente').click(function (e) {
    var step = $(this).attr('data-step');
    $(this).closest('fieldset').slideUp('slow');
    $('#step' + step).slideDown('slow');
});