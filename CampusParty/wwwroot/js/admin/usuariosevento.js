$(document).ready(function () {

    $(document).on('click', '.delete-user-event', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let usuarioEventoId = $(e.currentTarget).data('itemid');
        eliminarUsuarioEvento(usuarioEventoId);
    });
});


function eliminarUsuarioEvento(usuarioEventoId) {
    $.ajax({
        url: '/UsersEvent/DeleteUserEvent',
        type: 'DELETE',
        data: {
            idUsuarioEvento: usuarioEventoId,
            idPabellon: $('#pabellonId').val()
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}