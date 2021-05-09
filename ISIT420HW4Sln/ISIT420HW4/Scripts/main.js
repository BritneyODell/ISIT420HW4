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

function getMarkups() {
    $("#markupsList").empty();
    $.getJSON("api/stores/GetMarkups")
        .done(function (data) {
            // On success, 'data' contains a list of the stores and the number of sales they made above $13
            $('#markupsList').append(`<li><strong> [${data[0].city}], [${data[0].state}] is the top store, with [${data[0].count}] orders with ideal markups (over $13). </strong></li>`);
            $('#markupsList').append(`<li> [${data[1].city}], [${data[1].state}] is tied for first with [${data[1].count}] orders. </li>`);
            $('#markupsList').append(`<li> [${data[2].city}], [${data[2].state}] is after them with [${data[2].count}] orders. </li>`);
            $('#markupsList').append(`<li> Next up is [${data[3].city}], [${data[3].state}] with the same [${data[3].count}] orders. </li>`);
            $('#markupsList').append(`<li> And finally, [${data[4].city}], [${data[4].state}] comes fourth, with [${data[4].count}] orders. </li>`);
            $('#markupsList').append(`<li> have a nice day :)</li>`);
            console.log(data);
        });
}
