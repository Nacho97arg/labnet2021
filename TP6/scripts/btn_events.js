"use strict";

$(document).ready(function(){
    $('#btnLimpiarCampos').click(function(){
        $('.fields').val("");
    });

    $('#btnSubmit').click(function(){
        let nombreValue = $('#txtNombre').val();
        let apellidoValue = $('#txtApellido').val();

        if ((nombreValue === "") || (apellidoValue === ""))
            alert("Verifique que los campos de nombre y apellido esten completos");
    })
});