$(document).ready(function () {

    $(document).on('click', '#carpa', function () {
        $('#formCarpa').toggleClass('d-none');
    });

    $(document).on('click', '#vehiculo', function () {
        $('#formVehiculo').toggleClass('d-none');
    });

    $(document).on('click', '#computador', function () {
        $('#formComputador').toggleClass('d-none');
    });

    $(document).on('click', '#videojuego', function () {
        $('#formVideojuego').toggleClass('d-none');
    });

    $(document).on('click', '#softwareEducativo', function () {
        $('#formSoftwareEducativo').toggleClass('d-none');
    });

    $(document).on('click', '.open-register-moda-button', function (e) {
        setRegisterEventModalData(e);
    });

    $(document).on('click', '#registerUserToEvent', function (e) {
        registerUserToEvent(e);
    });

    
});


function setRegisterEventModalData(e){
    let pabellonSelector = $('#pabellonSelector');
    let equipoSelector = $('#equipoSelector');

    $(pabellonSelector).html('');
    $(equipoSelector).html('');

    let pabellones = $(e.currentTarget).data('pabellones');
    let equipos = $(e.currentTarget).data('equipos');

    $('#registerUserToEvent').data('itemid', $(e.currentTarget).data('itemid'));
    $(pabellones).each(function () {
        $(pabellonSelector).append('<option data-itemid="' + this.PabellonId + '">' + this.Tematica + '</option>');
    });

    $(equipos).each(function () {
        $(equipoSelector).append('<option data-itemid="' + this.EquipoId + '">' + this.Nombre + '</option>');
    });
}

function getRegisterToEventData(e) {
    let equipos = $('#equipoSelector').find(':selected').map(function (index, element) {
        return $(element).data('itemid')
    }).toArray();

    let data = {
        Carpa: JSON.stringify({
            Color: $('#color').val(),
            Alto: $('#alto').val(),
            Largo: $('#largo').val(),
            Ancho: $('#ancho').val()
        }),
        Vehiculo: JSON.stringify({
            Placa: $('#placa').val(),
            Color: $('#colorVehiculo').val()
        }),
        Computador: JSON.stringify({
            Serial: $('#serial').val(),
            RAM: $('#ram').val(),
            DiscoDuro: $('#discoDuro').val(),
            Software: {
                Nombre: $('#nombreSoftware').val(),
                Valor: $('#valorSoftware').val(),
                Peso: $('#pesoSoftware').val(),
            },
            SoftwareEducativo: {
                Logros: $('#logros').val()
            },
            Videojuego: {
                ScoreMax: $('#puntajeMaximo').val(),
                Fabricante: $('#nombreFabricante').val()
            }
        }),
        EventoId: $(e.currentTarget).data('itemid'),
        Estadia: $('#estadia').is(':checked'),
        Equipos: equipos,
        PabellonId: $('#pabellonSelector').find(':selected').data('itemid')
    }

    return data;
}

function registerUserToEvent(e) {
    let data = getRegisterToEventData(e);

    $.ajax({
        url: '/MainEvent/RegisterUserToEvent',
        type: 'POST',
        data: {
            request: JSON.stringify(data)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}


