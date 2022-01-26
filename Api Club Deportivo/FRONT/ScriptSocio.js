$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44316/Deporte/ObtenerDeporte",
        type: "GET",
        success: function (result) {
            if (result.ok) {
                cargarComboBoxDeporte(result.return);
            } else {
                alert(result.error);
            }
        },
        error: function (error) {
            console.log(error);
        },
    });

});


function cargarComboBoxDeporte(datos) {
    select = document.getElementById("cmbDeporte");
    for (let i = 0; i < datos.length; i++) {
        var option = document.createElement("option");
        option.text = datos[i].nombre;
        option.value = datos[i].id;
        select.add(option);
    }
    console.log(select.value);
}



function agregarSocio(nombre, apellido, calle , numero, idDeporte) {
    comando = {
        nombre: nombre,
        apellido: apellido,
        calle: calle,
        numero: numero,
        idDeporte: idDeporte
    };
    $.ajax({
        url: "https://localhost:44316/Socio/CrearSocio",
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(comando),
        success: function (result) {
            if (result.ok) {
                alert("Socio Cargado");
                console.log(comando);
            } else {
                alert(result.error);
            }
        },
        error: function (error) {
            console.log(error);
        },
    });
}

$("#btnCrearSocio").click(function () {
    let nombre = $("#txtNombre").val();
    let apellido = $("#txtApellido").val();
    let calle = $("#txtCalle").val();
    let numero= $("#txtNumero").val();
    let idDeporte = $("select#cmbDeporte option:checked").val();
    
    numero = parseInt(numero);
    idDeporte= parseInt(idDeporte);
    agregarSocio(nombre, apellido, calle , numero, idDeporte);
});

