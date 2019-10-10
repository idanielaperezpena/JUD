moment.locale('es');

$(document).ready(function () {

    var $scope = 'body';

    initTextTransform($scope);
    initAutocomplete($scope);
    initAutoNumeric($scope);
    initDatepicker($scope);
    initDaterangepicker($scope);
    initTableChecks($scope);
    initCustomFile($scope);
});

function initAutoNumeric(scope) {

    $(scope).find('input:text[data-toggle="autoNumeric"], span[data-toggle="autoNumeric"], label[data-toggle="autoNumeric"]').each(function () {
        $this = $(this);

        $this.autoNumeric();
    });
}

function initCustomFile(scope) {

    $(scope).find('label.custom-file-label').text(function () { return $(this).data('empty-text'); });
    $(scope).find('input:file.custom-file-input').change(function (e) {

        var _input = $(e.target);
        var _label = _input.next('label.custom-file-label');

        if (_input.val()) {
            _label.text(e.target.files[0].name);

            if (_input.data("preview")) {
                var $reader = new FileReader();
                var _preview = $(_input.data("preview"));

                $reader.onload = function (e) {
                    _preview.attr('src', e.target.result);
                };

                $reader.readAsDataURL(e.target.files[0]);
            }
        }
        else
            _label.text(_label.data('empty-text'));
    });
}

function initTextTransform(scope) {

    $(scope).find('input:text[data-transform], textarea[data-transform]').each(function () {
        $this = $(this);

        var _trans = $this.data("transform");
        var _class = "text-uppercase";


        if (_trans)
            _trans = _trans.toLowerCase();

        switch (_trans) {
            case "lower":
                _class = "text-lowercase";
                $this.blur(function (e) {
                    $this.val($this.val().toLowerCase());
                });
                break;
            case "normal":
                _class = "";
                break;
            default:
                $this.blur(function (e) {
                    $this.val($this.val().toUpperCase());
                });
                break;
        }

        $this.addClass(_class);
    });
}

function initTableChecks(scope) {
    $(scope).find('input:checkbox[data-toggle="CheckTable"]').change(function (e) {
        var _table = $(e.target).closest("table");
        var _checkAll = _table.find('input:checkbox[name="chkListHeader"]');

        if (e.target.id === _checkAll.attr('id')) {

            var _checkItems;

            if (e.target.checked)
                _checkItems = _table.find('input:checkbox[name="chkListItem"]:not(:checked)');
            else
                _checkItems = _table.find('input:checkbox[name="chkListItem"]:checked');

            _checkItems.prop('checked', e.target.checked);
        }
        else {
            _checkAll.prop('checked', _table.find('input:checkbox[name="chkListItem"]:not(:checked)').length <= 0);
        }
    });
}

function initAutocomplete(scope) {
    $(scope).find('input:text[data-toggle="autocomplete"]').each(function () {
        var $this = $(this);

        var _idHolder = $($this.attr("data-id-holder"));
        var _appendTo = $this.attr("data-appendto");
        var _url = $this.attr("data-url");
        var _minLength = $this.attr("data-length");
        var _required = $this.attr("data-must-select") ? $this.attr("data-must-select") : "true";

        $this.on("keydown", function (e) {
            if (_idHolder && (e.keyCode === 46 || e.keyCode === 8))
                _idHolder.val('');
        });

        $this.autocomplete({
            appendTo: _appendTo ? _appendTo : 'body',
            source: function (request, response) {

                if (_idHolder)
                    _idHolder.val('');

                var _currentData = {
                    texto: request.term
                };

                switch (_url) {
                    default:
                        break;
                }

                $.ajax({
                    url: _url,
                    data: JSON.stringify(_currentData),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) { onAutocompleteSearchingSuccess(data, response, $this); },
                    error: onAutocompleteError,
                    failure: onAutocompleteError
                });
            },
            minLength: _minLength ? _minLength : 1,
            select: function (event, ui) { onAutocompleteItemSelected(event, ui, _idHolder); }
        });

        if (_required === "true")
            $this.on('autocompletechange', function (event, ui) { onAutocompleteChange(event, ui, _idHolder); });

        $this.autocomplete("instance")._renderItem = onAutocompleteRenderItem;
    });
}

function initDatepicker(scope) {

    var _defaults = {
        format: 'mm/yyyy',
        autoclose: true,
        clearBtn: true,
        language: 'es',
        minViewMode: 1
    };

    $(scope).find('input:text[data-toggle="datepicker"]').each(function () {
        $this = $(this);
        var _customDef = jQuery.extend({}, _defaults);
        var _minView = $this.data('min-viewmode');
        var _format = $this.data('format');

        if (_minView)
            _customDef.minViewMode = _minView;

        if (_format)
            _customDef.format = _format.toLowerCase();

        $this.attr("readonly", "readonly");
        $this.datepicker(_customDef);

        //Se agrega el handler al icono X para limpiar el campo
        $this.closest('.calendar-control').find('.icon-clear').click(function (e) {
            $this.val('');
        });
    });
}

function initDaterangepicker(scope) {

    var _defaults = {
        showDropdowns: true,
        autoUpdateInput: false,
        locale: {
            format: 'L',
            fromLabel: 'Desde',
            toLabel: 'Hasta',
            applyLabel: 'Aplicar',
            cancelLabel: 'Limpiar'
        }
    };

    $(scope).find('input:text[data-toggle="daterangepicker"]').daterangepicker(jQuery.extend({}, _defaults))
        .attr("readonly", "readonly")
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val('');
        }).on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('L') + ' - ' + picker.endDate.format('L'));
        });

    var _singleDefaults = jQuery.extend({}, _defaults);
    _singleDefaults.singleDatePicker = true;

    $(scope).find('input:text[data-toggle="daterangepickersingle"]').daterangepicker(_singleDefaults)
        .attr("readonly", "readonly")
        .on('cancel.daterangepicker', function (ev, picker) {
            $(this).val('');
        }).on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('L'));
        });

    //Se agrega el handler al icono X para limpiar el campo
    $(scope).find('input:text[data-toggle="daterangepicker"], input:text[data-toggle="daterangepickersingle"]').closest('.calendar-control').find('.icon-clear').click(function (e) {
        $(this).closest('.calendar-control').find('input:text').trigger('cancel.daterangepicker');
    });
}

///Genera una vista personalizada de cada elemento del autocompletado
function onAutocompleteRenderItem(ul, item) {

    var _header = item.label !== null ? "<div class='ui-menu-item-header'>" + item.label + "</div>" : "";
    var _details = item.details !== null ? "<div class='ui-menu-item-detail'>" + item.details + "</div>" : "";

    return $("<li>")
        .append("<div>" + _header + _details + "</div>")
        .appendTo(ul);
}

///Mapea el objeto devuelto por el servicio de sugerencias
function onAutocompleteSearchingSuccess(data, response, sender) {

    var _data = $.map(data, function (item) {

        return {
            val: item.Id,
            label: item.Nombre,
            details: item.Detalle,
            fullData: item
        };
    });

    response(_data);
}

///Cuando un elemento de la lista de coincidencias es seleccionado, asigna el ID del item y provoca un postback
function onAutocompleteItemSelected(event, ui, idHolder) {

    if (idHolder) {
        idHolder.val(ui.item.val);
    }

    $(event.target).val(ui.item.label);
}

///Muestra una notificación en caso de que el response al servicio de sugerencias sea un error
function onAutocompleteError(response) {
    mostrarNotificacion('', response.responseText, 'warning', '', true);
}

function onAutocompleteChange(event, ui, idHolder) {
    if (!ui.item) {

        if (idHolder)
            idHolder.val('');

        $(event.target).val("");
    }
}

function initAjaxForm(scope) {

    var _formSelector = scope + ' form';

    $(_formSelector).validate().destroy();
    $(_formSelector).on("invalid-form.validate", onInvalidForm);
    $.validator.unobtrusive.parse(_formSelector);
}