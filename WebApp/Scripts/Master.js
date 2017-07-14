//(function () {
//    jQuery.validator.methods.date = function (value, element) {
//        var formats = ["DD/MM/YYYY", "DD/MM/YYYY HH:mm"];
//        return moment(value, formats, true).isValid();
//    };
//})(jQuery, moment);

$(document).ready(function () {

    // DataTable
    $('.table').DataTable({
        language: {
            url: "../Scripts/DataTables/Spanish.json",
            decimal: ".",
            thousands: ","
        }
    })

    $("input:text,form").attr("autocomplete", "off");
    
    $('.date').datetimepicker({
        viewMode: 'days',
        format: 'DD/MM/YYYY',
        locale: 'es',
        ignoreReadonly: true
    });
});