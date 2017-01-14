$(function () {
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }
});

$(window).ajaxStart(function () {
    lvBase.mostrarMensagem('<b>' + aguardeProcessamento + '</b>');
});

$(window).ajaxComplete(function (e, result, settings) {
    setTimeout("$('div.jGrowl').find('.jGrowl-close').trigger('jGrowl.close')", 200);
    var ct = result.getResponseHeader("content-type");
    if (ct != null && ct.indexOf('json') > -1) {
        var response = $.parseJSON(result.responseText);
        if (response.redirect) {
            document.location.href = response.urlRedirect;
        }
    }
});

var lvBase = {
    urlContent: urlContent,

    iniciarFormModal: function (divContainer, result) {
        var container = $(divContainer);
        container.empty().append(result);
        container.children().modal({ backdrop: 'static' });
        var form = container.find('form');

        $('.submitForm').on('click', function () {
            form.submit();
        });

        if (form) {
            try {
                $(form).find('input[type=text],textarea,select').filter(':visible:first').focus();
                $.validator.unobtrusive.parse(form);
            } catch (e) {
                console.log('Erro jquery validate unobstrusive: ' + e);
            }
        }
    },

    mostrarMensagem: function (mensagem, tipo) {
        $.jGrowl(mensagem, { life: 6000, openDuration: 0, position: 'bottom-right' });
    },

    processarAfterSubmitModal: function (result, divContainer, callback) {
        if (result.sucesso) {
            $(divContainer).find('.modal').on('hidden.bs.modal', function (e) {
                $(divContainer).find('.modal').modal('hide');
                $(divContainer).empty();
                if (callback) {
                    callback();
                }
                setTimeout(function () { lvBase.mostrarMensagem(result.mensagem, result.tipo); }, 400);
                $(divContainer).empty();
            }).modal('hide');
        } else {
            $(divContainer).find('.modal').on('hidden.bs.modal', function (e) {
                lvBase.iniciarFormModal(divContainer, result);
            }).modal('hide');
        }
    },

    processarAfterDelete: function (result, callback) {
        if (result.sucesso) {
            setTimeout(function () { lvBase.mostrarMensagem(result.mensagem, result.tipo); }, 400);
            if (callback) {
                callback();
            }
        } else {
            setTimeout(function () { lvBase.mostrarMensagem(result.mensagem, result.tipo); }, 400);
        }
    },
};