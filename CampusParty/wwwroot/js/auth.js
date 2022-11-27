$(document).ready(function (e) {

    $(document).on('click', '#register', function (e) {
        register();
    });

    $(document).on('click', '#login', function (e) {
        logIn();
    });

    $(document).on('click', '#logout', function (e) {
        logOut();
    });
});



function register() {
    let usuario = {
        Correo: $('#email').val(),
        Contraseña: $('#password').val(),
        NombreCompleto: $('#nombre').val(),
        Documento: $('#documento').val(),
        Telefono: $('#telefono').val(),
        FechaNacimiento: $('#fecha-nacimiento').val(),
        CiudadId: $('#dropdownCity').find(":selected").data('itemid')
    };

    $.ajax({
        url: '/Auth/Register',
        type: 'POST',
        data: {
            request: JSON.stringify(usuario)
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function logIn() {

    let correo = $('#email').val();
    let contraseña = $('#password').val();

    $.ajax({
        url: '/Auth/SignIn',
        type: 'POST',
        data: {
            correo: correo,
            password: contraseña
        }
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}

function logOut() {

    $.ajax({
        url: '/Auth/LogOut',
        type: 'POST'
    }).done(function (result) {
        if (result.status == 200) {
            window.location.href = result.actionLink;
        }
    }).fail(function (result) {
        console.log(result);
    });
}