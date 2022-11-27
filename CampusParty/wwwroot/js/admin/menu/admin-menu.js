$(document).ready(function () {
    showNavbar("header-toggle", "nav-bar", "body-pd", "header");

    const linkColor = $(".nav_link");

    function colorLink(e) {
        if (linkColor) {
            $(linkColor).each(function () {
                $(this).removeClass('active');
            });

            $(e.currentTarget).addClass("active");
        }
    }
    $(linkColor).each(function () {
        $(this).click(function (e) {
            colorLink(e);
        });
    });
})

function showNavbar(toggleId, navId, bodyId, headerId) {
    const toggle = $('#' + toggleId),
        nav = $('#' + navId),
        bodypd = $('#' + bodyId),
        headerpd = $('#' + headerId);

    // Validate that all variables exist
    if (toggle && nav && bodypd && headerpd) {
        $(toggle).click(function () {
            $(nav).toggleClass("show-menu");
            // change icon
            $(toggle).toggleClass("bx-x");
            // add padding to body
            $(bodypd).toggleClass("body-pd");
            // add padding to header
            $(headerpd).toggleClass("body-pd");
        });


    }
}