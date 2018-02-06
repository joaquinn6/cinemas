function cambiar(asiento) {
    var clase = $(asiento).attr('class');
    var clases = clase.split(" ");

    if (clases[2] == "libre") {
        $(asiento).removeClass("libre");
        $(asiento).addClass("seleccionado");
    } else {
        $(asiento).removeClass("seleccionado");
        $(asiento).addClass("libre");
    }
}