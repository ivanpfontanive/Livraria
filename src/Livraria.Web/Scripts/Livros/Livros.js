$(function () {
    lvLivros.init();
});

var lvLivros = {
    url: lvBase.urlContent + 'Livros/',
    btnAdicionar: '#btnAdicionar',
    btnEditar: '.btnEditar',
    btnDeletar: '.btnDeletar',
    divFormContent: '#divFormContent',
    divTable: '#divTable',

    init: function () {
        $(this.btnAdicionar).on('click', function () {
            lvLivros.add();
        });

        this.list();
    },

    add: function () {
        $.ajax({
            url: lvLivros.url + 'Create',
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvLivros.divFormContent, result);
            }
        });
    },
    edit: function (id) {
        $.ajax({
            url: lvLivros.url + 'Edit',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.iniciarFormModal(lvLivros.divFormContent, result);
            }
        });
    },
    list: function () {
        $.ajax({
            url: lvLivros.url + 'List',
            type: 'get',
            success: function (result) {
                $(lvLivros.divTable).html(result);

                $(lvLivros.btnEditar).on('click', function () { lvLivros.edit($(this).data('id')); });
                $(lvLivros.btnDeletar).on('click', function () { lvLivros.deletar($(this).data('id')); });
            }
        });
    },

    afterSubmit: function (result) {
        lvBase.processarAfterSubmitModal(result, lvLivros.divFormContent, lvLivros.list);
    },

    deletar: function (id) {
        $.ajax({
            url: lvLivros.url + 'Delete',
            data: { id: id },
            type: 'get',
            success: function (result) {
                lvBase.processarAfterDelete(result, lvLivros.list);
            }
        });
    },
}