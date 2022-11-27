$(document).ready(function () {

    $(document).on('click', '#crearPabellon', function (e) {
        crearPabellon(e);
    });

    $(document).on('click', '#editPabellon', function (e) {
        editarPabellon(e);
    });

    $(document).on('click', '.delete-pabellon', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let pabellonId = $(e.currentTarget).data('itemid');
        eliminarPabellon(pabellonId);
    });
});

function crearPabellon(e) {
    let pabellon = {
        Tematica: $('#tematica').val(),
        Area: $('#area').val(),
        Ubicacion: $('#ubicacion').val(),
        EventoId: $('#eventId').val()
    };

    $.ajax({
        url: '/Pabellon/CreatePabellon',
        type: 'POST',
        data: {
            request: JSON.stringify(pabellon)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function editarPabellon(e) {
    let pabellon = {
        PabellonId: $('#pabellonId').val(),
        Tematica: $('#tematica').val(),
        Area: $('#area').val(),
        Ubicacion: $('#ubicacion').val(),
        EventoId: $('#eventId').val()
    };

    $.ajax({
        url: '/Pabellon/EditPabellon',
        type: 'PUT',
        data: {
            request: JSON.stringify(pabellon)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function eliminarPabellon(pabellonId) {
    $.ajax({
        url: '/Pabellon/DeletePabellon',
        type: 'DELETE',
        data: {
            idPabellon: pabellonId,
            idEvento: $('#eventId').val()
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}