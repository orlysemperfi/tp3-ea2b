function cerrarDiv(idDiv) {
    document.getElementById(idDiv).innerHTML = "";
    document.getElementById(idDiv).style.display = 'none';
}

function crearMensaje(msgMostrar) {
    elemento = document.createElement("label");
    elemento.innerHTML = msgMostrar;
    document.getElementById("mensajeError").appendChild(elemento);
    document.getElementById("mensajeError").style.display = 'inline-block';
    setTimeout("cerrarDiv('mensajeError')", 5000);
}

function mostrarDiv(idDiv) {
    document.getElementById(idDiv).style.display = 'inline-block';
}

function ocultarDiv(idDiv) {
    document.getElementById(idDiv).style.display = 'none';
}