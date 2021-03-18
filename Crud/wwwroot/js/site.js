// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function retornaURL() {
    var url = document.URL.split("listar/");
    return url[0].replace("?", "").replace("#", "");
}

function CadastrarProduto() {    
    var $form = $("#inserirProduto");
    var data = getFormData($form);
    if (data.descricao == '' || data.nome == '' || data.precovenda == '') {
        alert('Todos os campos com asterisco são obrigatórios');
        return;
    } 
    var form_data = new FormData($("#inserirProduto")[0])
    $.ajax({
        type: 'POST',
        url: retornaURL() + 'Cadastrar',
        data: form_data,
        processData: false,
        contentType: false,
        success: function (result) {
            if (result != 'OK')
                alert(result);
            setTimeout(function () {
                location.reload();
            }, 400);
        },
        error: function (result) {
            alert('Houve um erro ao cadastrar o produto');
        }
    });    
}

function AtualizarProduto() {
    var $form = $("#editarProduto");
    var data = getFormData($form);
    if (data.descricao == '' || data.nome == '' || data.precovenda == '') {
        alert('Todos os campos com asterisco são obrigatórios');
        return;
    } 
    var form_data = new FormData($("#editarProduto")[0])
    $.ajax({
        type: 'POST',
        url: retornaURL() + 'Atualizar',
        data: form_data,
        processData: false,
        contentType: false,
        success: function (result) {
            if (result != 'OK')
                alert(result);
            setTimeout(function () {
                location.reload();
            }, 400);
        },
        error: function (result) {
            alert('Houve um erro ao cadastrar o produto');
        }
    });
}

function getBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        console.log(reader.result);
    };
    reader.onerror = function (error) {
        console.log('Error: ', error);
    };
}

function EditarRegistro(id) {
    $("#editModal").modal();
    $("#id_produto_editar").val(id);
    $.ajax({
        type: 'GET',
        url: retornaURL() + 'obterProduto/' + id,
        success: function (data) {
            $("#nomeEditar").val(data.nome);
            $("#descricaoEditar").val(data.descricao);
            $('#precovendaEditar').val(data.precoVenda);
            $('#categoriaEdit').val(data.idcategoria);
            $('#formFile').val(data.formfile);
        },
        error: function (result) {
            alert('Houve um erro ao');
        }
    });
}

$('#texto_pesquisa').blur(function () {

    if ($('#texto_pesquisa').val() != undefined && $('#texto_pesquisa').val() != '') {
        window.open(retornaURL() + "listar/" + $('#texto_pesquisa').val(), "_self");
    }
    else if ($('#pesquisa_salva').val() != $('#texto_pesquisa').val()) {
        window.open(retornaURL(), "_self");
    }
})

function IncluirRegistro() {
    $("#addModal").modal();
}

function Excluir() {
    if ($(".tipo-exclusao").val() == 'selecionados')
        ExcluirSelecionados();
    else
        ExcluiUnico($(".id-exclusao").val());
}

function ExcluiUnico(id) {
    $.ajax({
        url: retornaURL() + 'apagar/' + id,
        type: 'DELETE',
        data: id,
        success: function (result) {
            setTimeout(function () {
                location.reload();
            }, 400);
        }
    });
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function ExcluirSelecionados() {
    var searchIDs = $('table tbody span input:checkbox:checked').map(function () {
        return $(this).val();
    }).get();
    $.ajax({
        type: 'POST',
        url: retornaURL() + 'DeletarProdutosSelecionados',
        data: JSON.stringify({ ids: searchIDs }),
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        success: function (result) {
            setTimeout(function () {
                location.reload();
            }, 3000);
        }
    });
}

function ValidaExclusao(id) {
    $("#deleteModal").modal();
    if (id == undefined)
        $(".tipo-exclusao").val('selecionados');
    else {
        $(".tipo-exclusao").val('id');
        $(".id-exclusao").val(id);
    }
}

$('[data-toggle="tooltip"]').tooltip();
// Select/Deselect checkboxes
var checkbox = $('table tbody span input[type="checkbox"]');
$("#selectAll").click(function () {
    if (this.checked) {
        checkbox.each(function () {
            this.checked = true;
        });
    } else {
        checkbox.each(function () {
            this.checked = false;
        });
    }
});

checkbox.click(function () {
    if (!this.checked) {
        $("#selectAll").prop("checked", false);
    }
});

