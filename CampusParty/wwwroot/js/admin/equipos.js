$(document).ready(function () {

    $(document).on('click', '#crearEquipo', function (e) {
        crearEquipo(e);
    });

    $(document).on('click', '#editEquipo', function (e) {
        editarEquipo(e);
    });

    $(document).on('click', '.delete-equipo', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let equipoId = $(e.currentTarget).data('itemid');
        eliminarEquipo(equipoId);
    });
});

function crearEquipo(e) {
    let equipo = {
        Nombre: $('#nombreEquipo').val(),
        Titulo: $('#tituloEquipo').val(),
        Ciudad: $('#ciudadEquipo').val()
    };

    $.ajax({
        url: '/Team/CreateTeam',
        type: 'POST',
        data: {
            request: JSON.stringify(equipo)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function editarEquipo(e) {
    let equipo = {
        EquipoId: $('#equipoId').val(),
        Nombre: $('#nombreEquipo').val(),
        Titulo: $('#tituloEquipo').val(),
        Ciudad: $('#ciudadEquipo').val()
    };

    $.ajax({
        url: '/Team/EditTeam',
        type: 'PUT',
        data: {
            request: JSON.stringify(equipo)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function eliminarEquipo(equipoId) {
    $.ajax({
        url: '/Team/DeleteTeam',
        type: 'DELETE',
        data: {
            idEquipo: equipoId
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}