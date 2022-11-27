$(document).ready(function () {

    $(document).on('click', '.delete-usuario', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let usuarioId = $(e.currentTarget).data('itemid');
        eliminarEvento(usuarioId);
    });
});

function eliminarUsuario(usuarioId) {
    $.ajax({
        url: '/Users/DeleteUser',
        type: 'DELETE',
        data: {
            idUsuario: usuarioId
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}