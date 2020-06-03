var uriFbi = 'api/Fbi/GetAll';
var uriCensus = 'api/Census/GetAll';

$(document).ready(function () {

    //let people = $('#peopleSelect');
    //people.empty();
    //people.append('<option selected="true" disabled>Choose Person</option>');
    //people.prop('selectedIndex', 0);

    //$.getJSON(uriPeople).done(function (data) {
    //    $.each(data, function (key, item) {
    //        people.append($('<option></option>').attr('value', item.SalesPersonID).text(`${item.FirstName} ${item.LastName}`));
    //    });
    //});

});

function formatCensusItem(item) {
    return `ID: ${item.ID}, Year: ${item.Year}, Population: ${item.Population}`;
}

function findCensus() {
    $.getJSON(uriCensus)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatCensusItem(item) }).appendTo($('#Censuses'));
            });
        });
}

function formatFbiItem(item) {
    return `ID: ${item.ID}, Year: ${item.Year}, Murder: ${item.Murder}, ViolentCrime: ${item.ViolentCrime}, Robbery: ${item.Robbery}, Assault: ${item.Assault}, PropertyCrime: ${item.PropertyCrime}, Burglary: ${item.Burglary}, LarcenyTheft: ${item.LarcenyTheft}, MoterVehicleTheft: ${item.MoterVehicleTheft}`;
}

function findFbi() {
    $.getJSON(uriFbi)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatFbiItem(item) }).appendTo($('#fbis'));
            });
        });
}