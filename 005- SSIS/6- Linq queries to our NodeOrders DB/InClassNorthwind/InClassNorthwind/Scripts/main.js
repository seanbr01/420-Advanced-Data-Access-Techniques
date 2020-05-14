const  uri = 'api/northwind';
$(document).ready(function () {
    // Send an AJAX request
    GetShowData();
});

function formatItem1(item) {
    return item.OrderID + '   ' + item.Quantity + '   ' + item.UnitPrice + '    ' + item.ProductName;
}

function formatItem2(item) {
    return item.OrderID + '   ' + item.Quantity + '   ' + item.UnitPrice + '    ' + item.ShipName;
}


function formatItem3(item) {
    return `Order ID: ${item.OrderID}, Product Name: ${item.ProductName}, Discount: ${item.Discount}, OrderDate: ${item.OrderDate}, Shipped Date: ${item.ShippedDate}, Shipped City: ${item.ShipCity}`;
}

function formatItem4(item) {
    return `Order ID: ${item.OrderID}, Quantity: ${item.Quantity}, Unit Price: ${item.UnitPrice}, Product Name: ${item.ProductName}, Units In Stock: ${item.UnitsInStock}`;
}

function formatItem5(item) {
    return `Product Name: ${item.ProductName}, Order ID: ${item.OrderID}, Quantity: ${item.Quantity}, Unit Price: ${item.UnitPrice},  Units In Stock: ${item.UnitsInStock}`;
}


function GetShowData() {
    $.getJSON("api/northwind1")
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem1(item) }).appendTo($('#results1'));
            });
        });


    $.getJSON("api/northwind2")
         .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem2(item) }).appendTo($('#results2'));
            });
        });

    $.getJSON("api/northwind3")
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem3(item) }).appendTo($('#results3'));
            });
        });

    $.getJSON("api/northwind4")
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem4(item) }).appendTo($('#results4'));
            });
        });

    $.getJSON("api/northwind5")
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem5(item) }).appendTo($('#results5'));
            });
        });

}