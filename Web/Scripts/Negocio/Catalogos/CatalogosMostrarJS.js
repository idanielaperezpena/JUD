
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
    $('#modal-editar').modal('open');
    /*
    $.ajax({
        type: "POST",
        url: "/Catalogos/Add",
        data: id,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: "json",
        success: mensaje_exito,
        failure: mensaje_mal
    });
    */
});