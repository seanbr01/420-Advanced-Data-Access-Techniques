var uriFbiRevised = 'api/ISIT420/GetAllFbi';
var uriCensusRevised = 'api/ISIT420/GetAllCensus';
var uriFbiCensus = 'api/ISIT420/GetAllFbisAndCensus';
var uriPopVMurder = 'api/ISIT420/GetAllPopulationVersusMurder';
var uriPopVViolent = 'api/ISIT420/GetAllPopulationVersusViolentCrime';
var uriFirstLast = 'api/ISIT420/GetFristLast';
var uriYears = 'api/ISIT420/GetAllYears';
var uriGetByYear = 'api/ISIT420/GetByYear';

$(document).ready(function () {

    let store = $('#yearSelect');
    store.empty();
    store.append('<option selected="true" disabled>Choose Year</option>');
    store.prop('selectedIndex', 0);

    $.getJSON(uriYears).done(function (data) {
        $.each(data, function (key, item) {
            store.append($('<option></option>').attr('value', item.YearID).text(`${item.Year1}`));
        });
    });

});

function clearDisplay(display) {
    let view = $(display);
    view.empty();
}

function createDisplay(uri, display, format) {
    $.getJSON(uri)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: format(item) }).appendTo($(display));
            });
        });
}

function searchByYear() {
    $('#ByYear').text('');
    //alert(document.getElementById("yearSelect").value);
    var id = document.getElementById("yearSelect").value;
    $.getJSON(`${uriGetByYear}/${id}`)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatByYear(item) }).appendTo($('#ByYear'));
            });
        });
}

function formatByYear(item) {
    return `Year: ${item.Year1}, Population: ${item.Population}, Murder: ${item.Murder}
            , ViolentCrime: ${item.ViolentCrime}, Robbery: ${item.Robbery}, Assault: ${item.Assault}
            , PropertyCrime: ${item.PropertyCrime}, Burglary: ${item.Burglary}
            , LarcenyTheft: ${item.LarcenyTheft}, MoterVehicleTheft: ${item.MoterVehicleTheft}`;
}

//function findFirstLast() {
//    clearDisplay('#ByYear');
//    createDisplay(uriFirstLast, '#ByYear', formatByYear);
//}

function formatPopVMurder(item) {
    return `Year: ${item.Year1}, Population: ${item.Population}, Murder: ${item.Murder}`;
}

function findPopVMurder() {
    clearDisplay('#PopVMurder');
    createDisplay(uriPopVMurder, '#PopVMurder', formatPopVMurder);
}

function formatPopVViolentCrime(item) {
    return `Year: ${item.Year1}, Population: ${item.Population}, Violent Crime: ${item.ViolentCrime}`;
}

function findPopVViolentCrime() {
    clearDisplay('#PopVViolentCrime');
    createDisplay(uriPopVViolent, '#PopVViolentCrime', formatPopVViolentCrime);
}

function formatFbiCensusItem(item) {
    return `FbiID: ${item.ID}, YearID: ${item.YearID}, Year: ${item.Year1}, Population: ${item.Population}
            , Murder: ${item.Murder}, ViolentCrime: ${item.ViolentCrime}, Robbery: ${item.Robbery}, Assault: ${item.Assault}
            , PropertyCrime: ${item.PropertyCrime}, Burglary: ${item.Burglary}
            , LarcenyTheft: ${item.LarcenyTheft}, MoterVehicleTheft: ${item.MoterVehicleTheft}`;
}

function findCombined() {
    clearDisplay('#Combined');
    createDisplay(uriFbiCensus, '#Combined', formatFbiCensusItem);
}

function formatCensusItemRevised(item) {
    return `ID: ${item.ID}, YearID: ${item.YearID}, Year: ${item.Year1}, Population: ${item.Population}`;
}

function findCensusRevised() {
    clearDisplay('#CensusesRevised');
    createDisplay(uriCensusRevised, '#CensusesRevised', formatCensusItemRevised);
}

function formatFbiItemRevised(item) {
    return `ID: ${item.ID}, YearID: ${item.YearID}, Year: ${item.Year1}, Murder: ${item.Murder}
            , ViolentCrime: ${item.ViolentCrime}, Robbery: ${item.Robbery}, Assault: ${item.Assault}
            , PropertyCrime: ${item.PropertyCrime}, Burglary: ${item.Burglary}, LarcenyTheft: ${item.LarcenyTheft}
            , MoterVehicleTheft: ${item.MoterVehicleTheft}`;
}

function findFbiRevised() {
    clearDisplay('#fbisRevised');
    createDisplay(uriFbiRevised, '#fbisRevised', formatFbiItemRevised);
}