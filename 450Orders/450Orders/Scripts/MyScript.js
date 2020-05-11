var uri = 'api/orders';
//$(document).ready(function () {
//    // Send an AJAX request
//    $.getJSON(uri)
//        .done(function (data) {
//            // On success, 'data' contains a list of products.
//            $.each(data, function (key, item) {
//                // Add a list item for the product.
//                $('<li>', { text: formatItem(item) }).appendTo($('#orders'));
//            });
//        });
//});

function findAll() {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#orders'));
            });
        });
}

function formatItem(item) {
    return 'OrderID: ' + item.OrdersID + ', '
        + 'StoreNumberID: ' + item.StoreNumberID + ', '
        + 'SalesPersonID: ' + item.SalesPersonID + ', '
        + 'CdID: ' + item.CdID + ', '
        + 'Price: $' + item.Price + ', '
        + 'Datetime: ' + item.Datetime;
}

function find() {
    var id = $('#orderId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#orders').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#order').text('Error: ' + err);
        });
}
