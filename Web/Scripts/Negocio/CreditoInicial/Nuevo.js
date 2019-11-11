
//Grupos vulnerables

$(document).on('change', '#CIU_FechaNacimiento', function (e) {
    var fecha_nacimiento = new Date($(this).val());
    var ageDifMs = Date.now() - fecha_nacimiento;
    var ageDate = new Date(ageDifMs);
    var diff = ageDate.getUTCFullYear() - 1970;
    if (diff >= 60) {
        agregar_GP(3);
    } else {
        quitar_GP(3);
    }
});

$(document).on('change', '#CIU_IDgrupoEtnico', function (e) {
    var id = $(this).val();
    if (id != 1) {
        agregar_GP(4);
    } else {
        quitar_GP(4);
    }
});

$(document).on('change', '#CIU_IDEstadoCivil', function (e) {
    var id = $(this).val();
    if (id == 3 || id == 4) {
        agregar_GP(1);
    } else {
        quitar_GP(1);
    }
});

$(document).on('change', '#CIU_IDDiscapacidad', function (e) {
    var id = $(this).val();
    if (id != 6) {
        agregar_GP(5);
    } else {
        quitar_GP(5);
    }
});


function agregar_GP(id) {
    var ids = $('#CIU_IDGruposPrioritarios').val();
    if (jQuery.inArray(id, ids) === -1) {
        ids.push(id);
        $('#CIU_IDGruposPrioritarios').val(ids).trigger('change');
    }
}

function quitar_GP(id) {
    var ids = $('#CIU_IDGruposPrioritarios').val();
    if (jQuery.inArray(id, ids) !== -1) {
        var index = jQuery.inArray(id, ids);
        ids.splice(index, 1);
        $('#CIU_IDGruposPrioritarios').val(ids).trigger('change');
    }
}

// Buscar Ciudadano
$("#btn_Buscar").click(function (e) {
    e.preventDefault();
    if ($('#CadenaBusqueda').valid()) {
        var CadenaBusqueda = $('#CadenaBusqueda').val();
        $(this).closest('.box').append('<div class="overlay" id="cargar_busqueda"><i class= "fa fa-refresh fa-spin" ></i></div >');
        
        $.ajax({
            type: "POST",
            url: "/Ciudadano/BusquedaExistente",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ CadenaBusqueda: CadenaBusqueda }),
            success: function (e) {
                $('#cargar_busqueda').remove();
                $('#tabla_ciudadanos').html(e)              
            }
        });
    }
});

//Curp datos automaticos
$(document).on('change', '#CIU_CURP', function (e) {
    if ($(this).valid()) {
        var curp = $(this).val();
        var fecha = curp.substring(4, 10);
        var siglo_digito = curp.substring(16, 17);
        var fecha_array = fecha.split("");
        if (siglo_digito >= '0' && siglo_digito <= '9') {
            // Es de  1999
            siglo_digito = "19";
        } else {
            // Es de 2000
            siglo_digito = "20";
        }
        fecha = siglo_digito + fecha.substring(0, 2) + "-" + fecha.substring(2, 4) + "-" + fecha.substring(4, 6);
        $("#CIU_FechaNacimiento").val(fecha)
        var sexo = curp.substring(10, 11);
        if (sexo == "H")
            $("#CIU_IDGenero").val(1);
        else
            $("#CIU_IDGenero").val(2);
        var entidad = curp.substring(11, 13);
        nacimiento(entidad);

    }
});

var entidades_federativas = ["AS", "BC", "BS", "CC", "CS", "CH", "DF" ,"CL","CM","DG","GT","GR","HG","JC","MC","MN","MS","NT","NL","OC","PL","QO","QR","SP","SL","SR","TC","TS","TL","VZ","YN","ZS"]

function nacimiento(entidad) {
    if (jQuery.inArray(entidad, entidades_federativas) !== -1) {
        $("#CIU_IDEstado").val(jQuery.inArray(entidad, entidades_federativas) + 1)
    }
}

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
                $('#CIU_IDGruposPrioritarios').select2({ multiple: true });
                $('#foo').select2({ multiple: true });
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
            $('#CIU_IDGruposPrioritarios').select2({ multiple: true });
            $('#foo').select2({ multiple: true });
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
        Swal.fire({
            title: 'Ingresando la Solicitud',
            allowOutsideClick: false,
            onBeforeOpen: () => {
                Swal.showLoading()
            }
        })
        $.ajax({
            type: "POST",
            url: "/CreditoInicial/Insertar",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ viewModel: CreditoInicial }),
            success: function (e) {
                Swal.close();
                console.log(e)
                Swal.fire({
                    title: 'Solicitud Ingresada con exito',
                    allowOutsideClick: false,
                    /*onClose: () => {
                        window.location = "/CreditoInicial";
                    }*/
                })
            }
        });
    }
    
});

//Funcionamiento siguiente anterior
$(document).on('click', '.siguiente', function (e) {
    if ($(this).closest('form').valid()) {
        var step = $(this).attr('data-step');
        $(this).closest('fieldset').slideUp('slow');
        $('#step' + step).slideDown('slow');
    }
});