$(function () {
    lvGeneros.init();
});

var lvGeneros = {
    url: lvBase.urlContent + 'Generos/',
    btnAdicionar: '#btnAdicionar',
    btnEditar: '.btnEditar',
    btnDeletar: '.btnDeletar',
    divFormContent: '#divFormContent',
    divTable: '#divTable',

    init: function () {
        $(this.btnAdicionar).on('click', function () {
            lvGeneros.add();
        });

        this.list();
    },

    add: function () {
        $.ajax({
            url: lvGeneros.url + 'Create',
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvGeneros.divFormContent, result);
            }
        });
    },
    edit: function (id) {
        $.ajax({
            url: lvGeneros.url + 'Edit',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvGeneros.divFormContent, result);
            }
        });
    },
    list: function () {
        $.ajax({
            url: lvGeneros.url + 'List',
            type: 'get',
            success: function (result) {
                $(lvGeneros.divTable).html(result);

                $(lvGeneros.btnEditar).on('click', function () { lvGeneros.edit($(this).data('id')); });
                $(lvGeneros.btnDeletar).on('click', function () { lvGeneros.deletar($(this).data('id')); });
            }
        });
    },

    afterSubmit: function (result) {
        lvBase.processarAfterSubmitModal(result, lvGeneros.divFormContent, lvGeneros.list);
    },

    deletar: function (id) {
        $.ajax({
            url: lvGeneros.url + 'Delete',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.processarAfterDelete(result, lvGeneros.list);
            }
        });
    },
}