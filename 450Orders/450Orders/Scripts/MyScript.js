var uriOrders = 'api/Orders';
var uriPeople = 'api/SalesPerson';
var uriStores = 'api/Stores';
var uriSalespersonPerformance = 'api/SalespersonPerformance';
var uriStorePerformance = 'api/StorePerformance';

$(document).ready(function () {
    let people = $('#peopleSelect');
    people.empty();
    people.append('<option selected="true" disabled>Choose Person</option>');
    people.prop('selectedIndex', 0);

    $.getJSON(uriPeople).done(function (data) {
        $.each(data, function (key, item) {
            people.append($('<option></option>').attr('value', item.SalesPersonID).text(`${item.FirstName} ${item.LastName}`));
        });
    });

    let store = $('#storeSelect');
    store.empty();
    store.append('<option selected="true" disabled>Choose City</option>');
    store.prop('selectedIndex', 0);

    $.getJSON(uriStores).done(function (data) {
        $.each(data, function (key, item) {
            store.append($('<option></option>').attr('value', item.StoreNumberID).text(`${item.City}`));
        });
    });
});

function formatCdsOver11(item) {
    return `City: ${item.City}, CD Name: ${item.CDname}, Price: ${item.Price}`;
}

function searchForCdsOver11() {
    $.getJSON("api/CdsOver11")
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatCdsOver11(item) }).appendTo($('#searchCdsOver11'));
            });
        });
}

function formatSalesPersonPerformance(item) {
    return `Sales Person ID: ${item.SalesPersonID}, City: ${item.City}, Price: ${item.Price},  CD Name: ${item.CDname}`;
}

function searchPersonPerformance() {
    $('#searchPersonId').text('');
    var id = document.getElementById("peopleSelect").value;
    $.getJSON(`${uriSalespersonPerformance}/${id}`)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatSalesPersonPerformance(item) }).appendTo($('#searchPersonId'));
            });
        });
}

function formatStorePerformance(item) {
    return `City: ${item.City}, Price: ${item.Price},  Date: ${item.Datetime}`;
}

function searchStorePerformance() {
    $('#searchStoreId').text('');
    //alert(document.getElementById("storeSelect").value);
    var id = document.getElementById("storeSelect").value;
    $.getJSON(`${uriStorePerformance}/${id}`)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatStorePerformance(item) }).appendTo($('#searchStoreId'));
            });
        });
}

function formatItemById(item) {
    return `OrderID: ${item.OrdersID}, StoreNumberID: ${item.StoreNumberID}, SalesPersonID: ${item.SalesPersonID}, CdID: ${item.CdID}, Price: $${item.Price}, Datetime: ${item.Datetime}`;
}

function searchById() {
    var id = $('#orderId').val();
    $.getJSON(uriOrders + '/' + id)
        .done(function (data) {
            // Prints to element
            $('#searchById').text(formatItemById(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            // Prints error to element
            $('#searchById').text('Error: ' + err);
        });
}

function formatItem(item) {
    return `OrderID: ${item.OrdersID}, StoreNumberID: ${item.StoreNumberID}, SalesPersonID: ${item.SalesPersonID}, CdID: ${item.CdID}, Price: $${item.Price}, Datetime: ${item.Datetime}`;
}

function findAll() {
    // Send an AJAX request
    $.getJSON(uriOrders)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#orders'));
            });
        });
}