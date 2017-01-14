$(function () {
    lvAutores.init();
});

var lvAutores = {
    url: lvBase.urlContent + 'Autores/',
    btnAdicionar: '#btnAdicionar',
    btnEditar: '.btnEditar',
    btnDeletar: '.btnDeletar',
    divFormContent: '#divFormContent',
    divTable: '#divTable',

    init: function () {
        $(this.btnAdicionar).on('click', function () {
            lvAutores.add();
        });

        this.list();
    },

    add: function () {
        $.ajax({
            url: lvAutores.url + 'Create',
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvAutores.divFormContent, result);
            }
        });
    },
    edit: function (id) {
        $.ajax({
            url: lvAutores.url + 'Edit',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvAutores.divFormContent, result);
            }
        });
    },
    list: function () {
        $.ajax({
            url: lvAutores.url + 'List',
            type: 'get',
            success: function (result) {
                $(lvAutores.divTable).html(result);

                $(lvAutores.btnEditar).on('click', function () { lvAutores.edit($(this).data('id')); });
                $(lvAutores.btnDeletar).on('click', function () { lvAutores.deletar($(this).data('id')); });
            }
        });
    },

    afterSubmit: function (result) {
        lvBase.processarAfterSubmitModal(result, lvAutores.divFormContent, lvAutores.list);
    },

    deletar: function (id) {
        $.ajax({
            url: lvAutores.url + 'Delete',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.processarAfterDelete(result, lvAutores.list);
            }
        });
    },
}