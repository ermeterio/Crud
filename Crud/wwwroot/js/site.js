// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function EditarRegistro(id) {
	$("#editModal").modal();
}

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
		url: 'apagar/'+ id ,
		type: 'DELETE',
		data: id,
		success: function (result) {
			Location.reload();
		}
	});
}

function ExcluirSelecionados() {
	var searchIDs = $('table tbody span input[type="checkbox"]').map(function () {
		return $(this).val();
	}).get();
	$.ajax({
		type: 'POST',
		url: 'DeletarProdutosSelecionados',
		data: JSON.stringify({ ids: searchIDs }),
		contentType: 'application/json; charset=utf-8',
		datatype: 'json',
		success: function (result) {
			alert('Success ');
		},
		error: function (result) {
			alert('Fail ');
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

