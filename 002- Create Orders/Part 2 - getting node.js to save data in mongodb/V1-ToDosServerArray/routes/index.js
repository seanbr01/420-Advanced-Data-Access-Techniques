var express = require('express');
var router = express.Router();

function ToDo(pTitle, pDetail, pPriority) {
  this.title= pTitle;
  this.detail = pDetail;
  this.priority = pPriority;
}

var ServerToDos = [];
ServerToDos.push( new ToDo("Eat", "Eat dinner at 6:00", 1));
ServerToDos.push( new ToDo("Be Merry", "Tell bad jokes", 3));
ServerToDos.push( new ToDo("Drink", "Have wine with dinner", 2));

/* GET home page. */
router.get('/', function(req, res) {
  res.sendFile('index.html');
 
});

/* GET home page. */
router.get('/Todos', function(req, res) {
  res.send(ServerToDos);
 
});

/* GET home page. */
router.post('/NewToDo', function(req, res) {
  const onetoDo = req.body;
  ServerToDos.push(onetoDo);
  console.log (ServerToDos);
  res.status(200);
});


module.exports = router;
