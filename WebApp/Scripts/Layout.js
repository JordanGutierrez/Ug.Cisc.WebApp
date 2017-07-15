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

    $.ajaxSetup({ cache: false });

    // DataTable
    $('.table').DataTable({
        language: {
            url: "../Scripts/DataTables/Spanish.json",
            decimal: ",",
            thousands: "."
        }
    })
});