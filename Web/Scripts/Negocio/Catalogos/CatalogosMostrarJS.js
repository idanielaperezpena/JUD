﻿
$.extend($.fn.dataTable.defaults, {

    "language": {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecrcords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    },
    'paging': true,
    'lengthChange': false,
    "pageLength": 20,
    'searching': true,
    'ordering': true,
    'info': true,
    'autoWidth': true

});

$(document).ready(function () {
    $('#tabla_catalogos').dataTable();
});


$(document).on('click', '.edit', function (event) {
    var id = $(this).attr('data-id');
    var tabla = $('#Tabla').val();
    Swal.showLoading({ allowOutsideClick: false});
    $.ajax({
        type: "POST",
        url: "/Catalogos/GetVistaModal",
        data: {
            Tabla: tabla,
            ID : id
        },
        success: function (e) {
            Swal.close();
            $('#modal-cuerpo').html(e);
            $('#modal-editar').modal('show');
        }
    });

});

$(document).on('click', '.agregar', function (event) {
    var tabla = $('#Tabla').val();
    Swal.showLoading({ allowOutsideClick: false });
    $.ajax({
        type: "POST",
        url: "/Catalogos/GetVistaModal",
        data: {
            Tabla: tabla,
            ID : 0
        },
        success: function (e) {
            Swal.close();
            $('#modal-cuerpo').html(e);
            $('#modal-editar').modal('show');
        }
    });
});

$(document).on('click', '.eliminate', function (event) {
    var tabla = $('#Tabla').val();
    var id = $(this).attr('data-id');
    Swal.fire({
        type: 'question',
        title: '¿Estás seguro de eliminarlo?',
        text: 'Se desactivará esta opción para el sistema.',
        showCloseButton: true,
        showCancelButton: true,
        confirmButtonText:
            'Confirmar',
        cancelButtonText:
            'Cancelar',
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                type: 'success',
                title: 'Eliminado'
            })
        }
    })
});