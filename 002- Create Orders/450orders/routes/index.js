var express = require('express');
var router = express.Router();

const mongoose = require("mongoose");

const Orders = require("../Orders");

const dbURI = "mongodb+srv://bcuser:12345@cluster0-8ybiz.azure.mongodb.net/test?retryWrites=true&w=majority";

mongoose.set('useFindAndModify', false);

const options = {
  reconnectTries: Number.MAX_VALUE,
  poolSize: 10
};

mongoose.connect(dbURI, options).then(
  () => {
    console.log("Database connection established!");
  },
  err => {
    console.log("Error connecting Database instance due to: ", err);
  }
);

/* GET home page. */
router.get('/', function(req, res) {
  res.sendFile('index.html');
 
});

router.get('/Orders', function(req, res) {
  // find {  takes values, but leaving it blank gets all}
  Orders.find({}, (err, AllOrders) => {
    if (err) {
      console.log(err);
      res.status(500).send(err);
    }
    res.status(200).json(AllOrders);
  });
});

router.get('/RandomOrder', function(req, res) {

  var storeNumbers = [ 98053 , 98007, 98077, 98055, 98011, 98046 ];
  var randomNum = Math.floor(Math.random() * storeNumbers.length);
  var persons = [ randomNum * 4 + 1, randomNum * 4 + 2, randomNum * 4 + 3, randomNum * 4 + 4 ];

  var itemNumbers = [ 123456, 123654, 321456, 321654, 654123, 654321, 543216, 354126, 621453, 623451 ];

  

  function randomPurch(min, max) {  
      return Math.floor(Math.random() * (max - min) + min);
  }

  var order = {
      storeNumber: storeNumbers[randomNum],
      salesPersonID: persons[Math.floor(Math.random() * persons.length)],
      itemNumber: itemNumbers[Math.floor(Math.random() * itemNumbers.length)],
      timePurch: Date(Date.now()),
      // timePurch: randomDate(new Date(2012, 0, 1), new Date()),
      pricePaid: randomPurch(5, 16)
  }

  res.send(order);
});

router.get('/450RandomOrders', function(req, res) {

  var storeNumbers = [ 98053 , 98007, 98077, 98055, 98011, 98046 ];
  var randomNum = Math.floor(Math.random() * storeNumbers.length);
  var persons = [ randomNum * 4 + 1, randomNum * 4 + 2, randomNum * 4 + 3, randomNum * 4 + 4 ];

  var itemNumbers = [ 123456, 123654, 321456, 321654, 654123, 654321, 543216, 354126, 621453, 623451 ];

  function add_minutes (dt, minutes) {
    return new Date(dt.getTime() + minutes*60000);
  }

  function randomPurch(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
  }

  let orders = [];
  for (let index = 0; index < 450; index++) { 
    var order = {
      storeNumber: storeNumbers[randomNum],
      salesPersonID: persons[Math.floor(Math.random() * persons.length)],
      itemNumber: itemNumbers[Math.floor(Math.random() * itemNumbers.length)],
      timePurch: add_minutes(new Date(), index * 5),
      pricePaid: randomPurch(5, 16)
    };
    orders[index] = order;
  }
  
  res.send(orders);
});

router.post('/NewOrder', function(req, res) {

  let oneNewOrder = new Orders(req.body);  
  //console.log(req.body);
  oneNewOrder.save((err, order) => {
    if (err) {
      res.status(500).send(err);
    }
    else {
    //console.log(order);
    res.status(201).json(order);
    }
  });
});

router.delete('/DeleteOrder/:id', function (req, res) {
  Orders.deleteOne({ _id: req.params.id }, (err, note) => { 
    if (err) {
      res.status(404).send(err);
    }
    res.status(200).json({ message: "Order successfully deleted" });
  });
});

router.put('UpdateOrder',  function (req, res) {
  console.log('task id at server is ' + req.params.taskid);
  Order.findOneAndUpdate(
    { _id: req.body._id },  // don't know if this will work, normally pass _id in url like delete
    req.body,
    { new: true },  // true or false to let it add if not present?
    (err, order) => {
      if (err) {
        res.status(500).send(err);
      }
      console.log(note);
      res.status(200).json(oneNewOrder);
    }
  )
});

module.exports = router;
