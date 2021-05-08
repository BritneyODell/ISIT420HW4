$(document).ready(function () {
    getAllEmployeeNames();
    getAllStoreCities();
});

var salesPersonId = 0;

function getAllEmployeeNames() {
    $.getJSON("api/employees/GetAllEmployeeNames")
        .done(function (data) {
            // On success, 'data' contains a list of all employees' first name and last name
            $.each(data, function (index, value) {
                var fullName = value.FirstName + ' ' + value.LastName;
                $('#selectEmployee').append(`<option>${fullName}</option>`);
            });
        });
}

function getAllStoreCities() {
    $.getJSON("api/stores/GetAllStoreCities")
        .done(function (data) {
            // On success, 'data' contains a list of all store cities
            $.each(data, function (index, value) {
                $('#selectCity').append(`<option>${value.City}</option>`);
            });
        });
}

function getEmpTotal() {
    var employeeName = $('#selectEmployee option:selected').text();
    $.getJSON("api/orders/GetEmpTotal?employeeName=" + employeeName)
        .done(function (data) {
            // On success, 'data' contains the total amount sold by the employee for the year
            var totalamt = `${data}`;
            var soldTotalMssg = 'This employee sold $' + totalamt + ' for the year';
            $('#empTotal').text(soldTotalMssg);
        });
}

function getCityTotal() {
    var storeCity = $('#selectCity option:selected').text();
    $.getJSON("api/orders/GetCityTotal?storeCity=" + storeCity)
        .done(function (data) {
            // On success, 'data' contains the total amount sold by the employee for the year
            var totalamt = `${data}`;
            var soldTotalMssg = 'This store sold $' + totalamt + ' for the year';
            $('#cityTotal').text(soldTotalMssg);
        });
}

