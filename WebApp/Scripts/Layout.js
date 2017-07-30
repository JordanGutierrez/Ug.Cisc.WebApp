(function () {
    jQuery.validator.methods.date = function (value, element) {
        var formats = ["DD/MM/YYYY", "DD/MM/YYYY HH:mm"];
        return moment(value, formats, true).isValid();
    };
})(jQuery, moment);

$(document).ready(function () {
    $('.date').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY',
        locale: 'es',
        ignoreReadonly: true
    });

    $('.table').DataTable({
        language: {
            url: "../Scripts/DataTables/Spanish.json",
            decimal: ",",
            thousands: "."
        }
    })
});

var ConsultarPasante = function (value, callback) {
    $.ajax({
        url: '../../Pasante/ConsultarPasante',
        dataType: "json",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ id: value}),
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            callback(data);
            $("#ModalPasantes").modal("hide");
        },
        error: function (xhr) {
            alert('error');
        }
    })
}

var MostrarPasantes = function() {
    $("#ModalPasantes").modal("show");
}

var ConsultarTutor = function (value, callback) {
    $.ajax({
        url: '../../Tutor/ConsultarTutor',
        dataType: "json",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ id: value }),
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            callback(data);
            $("#ModalTutores").modal("hide");
        },
        error: function (xhr) {
            alert('error');
        }
    })
}

var MostrarTutores = function () {
    $("#ModalTutores").modal("show");
}

var ConsultarInstitucion = function (value, callback) {
    $.ajax({
        url: '../../Institucion/ConsultarInstitucion',
        dataType: "json",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ id: value }),
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            callback(data);
            $("#ModalInstituciones").modal("hide");
        },
        error: function (xhr) {
            alert('error');
        }
    })
}

var MostrarInstituciones = function () {
    $("#ModalInstituciones").modal("show");
}