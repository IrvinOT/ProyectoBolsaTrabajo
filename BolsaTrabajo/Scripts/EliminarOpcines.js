let urlActual = window.location.pathname;
var opciones = document.getElementById("OpcionesLayout");
var padreOpciones = opciones.parentNode;

padreOpciones.removeChild(opciones);

if (urlActual == "/Cuenta/Login" || urlActual == "Cuenta/Login") {
    padreOpciones.parentNode.removeChild(padreOpciones);
}
