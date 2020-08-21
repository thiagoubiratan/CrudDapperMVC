$(document).ready(function () {
    $('#dataTable').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registro por página",
            "zeroRecords": "Nada encontrado - desculpe!",
            "info": "Mostrar página _PAGE_ de _PAGES_",
            "infoEmpty": "Nenhum registro disponível",
            "infoFiltered": "(Filtrado de _MAX_ Registros totais)",
            "search": "Pesquisa:",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            }
        }
    });
});