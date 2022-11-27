$(document).ready(function () {

    $(document).on('click', '#crearEvento', function (e) {
        crearEvento(e);
    });

    $(document).on('click', '#editEvent', function (e) {
        editarEvento(e);
    });

    $(document).on('click', '.delete-event', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let eventId = $(e.currentTarget).data('itemid');
        eliminarEvento(eventId);
    });
});

function crearEvento(e) {
    let evento = {
        Nombre: $('#nombreEvento').val(),
        Descripcion: $('#descEvento').val(),
        Temas: $('#temasEvento').val(),
        Estado: $('#estado').is(':checked'),
        FechaInicio: $('#fechaInicio').val(),
        FechaFin: $('#fechaFin').val()
    };

    $.ajax({
        url: '/Event/CreateEvent',
        type: 'POST',
        data: {
            request: JSON.stringify(evento)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function editarEvento(e) {
    let evento = {
        EventoId: $('#eventId').val(),
        Nombre: $('#nombreEvento').val(),
        Descripcion: $('#descEvento').val(),
        Temas: $('#temasEvento').val(),
        Estado: $('#estado').is(':checked'),
        FechaInicio: $('#fechaInicio').val(),
        FechaFin: $('#fechaFin').val()
    };

    $.ajax({
        url: '/Event/EditEvent',
        type: 'PUT',
        data: {
            request: JSON.stringify(evento)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function eliminarEvento(eventId) {
    $.ajax({
        url: '/Event/DeleteEvent',
        type: 'DELETE',
        data: {
            idEvento: eventId
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}