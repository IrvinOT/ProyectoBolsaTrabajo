var btnA = document.getElementById('btnAgregar');
var btnE = document.getElementById('btnEliminar');
var txtCarreras = document.getElementById('txtCarreras');
var listCarreras = document.getElementById('listCarreras');


btnA.addEventListener("click", agregarCarrera);
btnE.addEventListener("click", EliminarCarreras);


function agregarCarrera() {
    var sCarreras = txtCarreras.value;
    var slista = listCarreras.value
    if (sCarreras == "") {
        txtCarreras.value = slista + " ,";
    } else {
        if (!sCarreras.includes(slista))
            txtCarreras.value += slista + ",";
    }
}

function EliminarCarreras() {
    txtCarreras.value = "";
}

