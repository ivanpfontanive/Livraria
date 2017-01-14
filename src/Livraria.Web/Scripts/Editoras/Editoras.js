$(function () {
    lvEditoras.init();
});

var lvEditoras = {
    url: lvBase.urlContent + 'Editoras/',
    btnAdicionar: '#btnAdicionar',
    btnEditar: '.btnEditar',
    btnDeletar: '.btnDeletar',
    divFormContent: '#divFormContent',
    divTable: '#divTable',

    init: function () {
        $(this.btnAdicionar).on('click', function () {
            lvEditoras.add();
        });

        this.list();
    },

    add: function () {
        $.ajax({
            url: lvEditoras.url + 'Create',
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvEditoras.divFormContent, result);
            }
        });
    },
    edit: function (id) {
        $.ajax({
            url: lvEditoras.url + 'Edit',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvEditoras.divFormContent, result);
            }
        });
    },
    list: function () {
        $.ajax({
            url: lvEditoras.url + 'List',
            type: 'get',
            success: function (result) {
                $(lvEditoras.divTable).html(result);

                $(lvEditoras.btnEditar).on('click', function () { lvEditoras.edit($(this).data('id')); });
                $(lvEditoras.btnDeletar).on('click', function () { lvEditoras.deletar($(this).data('id')); });
            }
        });
    },

    afterSubmit: function (result) {
        lvBase.processarAfterSubmitModal(result, lvEditoras.divFormContent, lvEditoras.list);
    },

    deletar: function (id) {
        $.ajax({
            url: lvEditoras.url + 'Delete',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.processarAfterDelete(result, lvEditoras.list);
            }
        });
    },
}