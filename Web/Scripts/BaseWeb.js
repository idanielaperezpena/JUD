var _currentAlert;

window.alert = function (message) {
    mostrarAlerta(message, 'info', undefined);
};

$.validator.setDefaults({
    onsubmit: false,
    onfocusout: false,
    onkeyup: false,
    normalizer: function (value) {
        return $.trim(value);
    }
});

$(document).ready(function () {
    PNotify.prototype.options.styling = "fontawesome";

    $('form, input:text').attr('autocomplete', 'off');
    $("form").on("invalid-form.validate", onInvalidForm);
    $('input:submit[data-val-method], button:submit[data-val-method]').click(onFormSubmit);
});

function mostrarAlerta(texto, tipo, titulo, hide) {

    if (_currentAlert)
        _currentAlert.remove();

    var options = {};

    if (titulo)
        options.title = titulo;

    if (tipo)
        options.type = tipo;

    if (texto)
        options.text = texto;

    if (hide)
        options.hide = hide;

    options.buttons = {
        closer: true,
        sticker: false
    };

    _currentAlert = new PNotify(options);
}

function mostrarLoader(loader) {

    if (!loader)
        loader = '#divLoader';

    $(loader).show();
}

function ocultarLoader(loader) {

    if (!loader)
        loader = '#divLoader';

    $(loader).hide();
}

function onInvalidForm(event, validator) {

    var _alerta = '';

    $.each(validator.errorList, function (index, item) {
        if (_alerta.indexOf(item.message) === -1) {
            _alerta += '<li>' + item.message + '</li>';
        }
    });

    _alerta = '<ul class="pnotify-errors">' + _alerta + '</ul>';
    mostrarAlerta(_alerta);
}

function resetForms(forms) {
    $.each(forms, function (idx, item) {
        $(item).validate().resetForm();
    });
}

function validarFormulario(sender, form, callback) {

    resetForms($('form').not(form));

    if (form.valid()) {

        if (_currentAlert)
            _currentAlert.remove();

        if (callback !== undefined)
            setTimeout(callback, 1);
        else
            submitForm(form);
    }
}

function validarCampos(fields, form) {

    resetForms($('form'));

    if (_currentAlert)
        _currentAlert.remove();

    var _isValid = fields.valid();

    if (!_isValid) {
        var _validator = form.validate();
        mostrarMensajeEstandar(_validator.errorList, '<ul class="pnotify-errors">@lista@</ul>', '<li>@msg@</li>');
    }

    return _isValid;
}

function onFormSubmit(e) {
    e.preventDefault();
    var _sender = $(this);
    window[_sender.data('val-method')](_sender, _sender.closest('form'));
}

function submitForm(form) {
    mostrarLoader();
    form.submit();
}

function openWindow(url, params) {

    var _new;

    if (!params)
        params = [];

    _new = window.open(url, "_blank", params.join(','));

    if (window.focus) {
        _new.focus();
    }
}

function openReport(url) {

    var _params =
        [
            'scrollbars=yes',
            'resizable=no',
            'fullscreen=no',
            'toolbar=no',
            'menubar=no',
            'titlebar=no',
            'location=no',
            'top=0',
            'left=0',
            'height=' + window.innerHeight,
            'width=' + window.innerWidth
        ];

    openWindow(url, _params);
}
