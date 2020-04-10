var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res) {
  res.sendFile('index.html');
 
});

router.get('/RandomOrder', function(req, res) {

  var storeNumbers = [ 98053 , 98007, 98077, 98055, 98011, 98046 ];
  var randomNum = Math.floor(Math.random() * storeNumbers.length);
  var persons = [ randomNum * 4 + 1, randomNum * 4 + 2, randomNum * 4 + 3, randomNum * 4 + 4 ];

  var itemNumbers = [ 123456, 123654, 321456, 321654, 654123, 654321, 543216, 354126, 621453, 623451 ];

  // didn't like the output...
  function randomDate(start, end) {
      return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
  }

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

/* GET home page. */
router.post('/NewOrder', function(req, res) {
  const Student = req.body;
  console.log (Student)
});


module.exports = router;
