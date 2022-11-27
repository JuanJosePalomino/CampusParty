$(document).ready(function () {

    $(document).on('click', '#crearCiudad', function (e) {
        crearCiudad(e);
    });

    $(document).on('click', '#editCity', function (e) {
        editarCiudad(e);
    });

    $(document).on('click', '.delete-city', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let cityId = $(e.currentTarget).data('itemid');
        eliminarCiudad(cityId);
    });
});

function crearCiudad(e) {
    let evento = {
        Nombre: $('#nombreCiudad').val(),
        NumeroHabitantes: $('#numeroHabitantes').val(),
        NumeroUniversidades: $('#numeroUniversidades').val()
    };

    $.ajax({
        url: '/City/CreateCity',
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

function editarCiudad(e) {
    let evento = {
        CiudadId: $('#cityId').val(),
        Nombre: $('#nombreCiudad').val(),
        NumeroHabitantes: $('#numeroHabitantes').val(),
        NumeroUniversidades: $('#numeroUniversidades').val()
    };

    $.ajax({
        url: '/City/EditCity',
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

function eliminarCiudad(cityId) {
    $.ajax({
        url: '/City/DeleteCity',
        type: 'DELETE',
        data: {
            idCiudad: cityId
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}