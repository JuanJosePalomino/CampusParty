$(document).ready(function () {

    $(document).on('click', '#crearSitio', function (e) {
        crearSitio(e);
    });

    $(document).on('click', '#editSite', function (e) {
        editarSitio(e);
    });

    $(document).on('click', '.delete-site', function (e) {
        $('#confirmDeleteAction').data('itemid', $(e.currentTarget).data('itemid'));
    });

    $(document).on('click', '#confirmDeleteAction', function (e) {
        let sitioId = $(e.currentTarget).data('itemid');
        eliminarSitio(sitioId);
    });
});

function crearSitio(e) {
    let sitio = {
        Codigo: $('#codigo').val(),
        Estado: $('#estado').is(':checked'),
        PabellonId: $('#pabellonId').val()
    };

    $.ajax({
        url: '/Site/CreateSite',
        type: 'POST',
        data: {
            request: JSON.stringify(sitio)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function editarSitio(e) {
    let sitio = {
        SitioId: $('#sitioId').val(),
        Codigo: $('#codigo').val(),
        Estado: $('#estado').is(':checked'),
        PabellonId: $('#pabellonId').val()
    };

    $.ajax({
        url: '/Site/EditSite',
        type: 'PUT',
        data: {
            request: JSON.stringify(sitio)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function eliminarSitio(sitioId) {
    $.ajax({
        url: '/Site/DeleteSite',
        type: 'DELETE',
        data: {
            idSite: sitioId,
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