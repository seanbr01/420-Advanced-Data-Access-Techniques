document.addEventListener("DOMContentLoaded", function (event) {

    document.getElementById("create").addEventListener("click", function () {
        
        $.get("/RandomOrder/", function(data, status){
            document.getElementById("storeNumber").innerHTML = JSON.stringify(data.storeNumber);
            document.getElementById("salesPersonID").innerHTML = JSON.stringify(data.salesPersonID);
            document.getElementById("itemNumber").innerHTML = JSON.stringify(data.itemNumber);
            document.getElementById("timePurch").innerHTML = JSON.stringify(data.timePurch);
            document.getElementById("pricePaid").innerHTML = JSON.stringify(data.pricePaid);
        });

    });

    document.getElementById("submit").addEventListener("click", function () {
        
        var order = {
            storeNumber: document.getElementById("storeNumber").innerHTML,
            salesPersonID: document.getElementById("salesPersonID").innerHTML,
            itemNumber: document.getElementById("itemNumber").innerHTML,
            timePurch: document.getElementById("timePurch").innerHTML,
            pricePaid: document.getElementById("pricePaid").innerHTML
        }
        
        // putting the theSubject in the URL for the PUT method
        $.ajax({
            url: '/NewOrder/' ,
            method: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(order),
            success: function (result) {
            }
        });

    });
    
    document.getElementById("bulk").addEventListener("click", function () {

        $.get("/450RandomOrders/", function(orders, status){
            for (let index = 0; index < orders.length; index++) {
                $.ajax({
                    url: '/NewOrder/' ,
                    method: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    data: JSON.stringify(orders[index]),
                    success: function (result) { }
                });
            }
        })
        
    });

    document.getElementById("display").addEventListener("click", function () {

        document.getElementById("mongoDisplay").innerHTML = '';
        $.get("/Orders/", function(orders, status){
            for (let index = 0; index < orders.length; index++) {

                var order = document.createElement("p");
                var text = document.createTextNode("Order Number " + index + " " + JSON.stringify(orders[index]));
                order.appendChild(text);

                var element = document.getElementById("mongoDisplay");
                element.appendChild(order);
            };
        })


        

    });

});