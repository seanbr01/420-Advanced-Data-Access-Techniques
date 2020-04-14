
function ToDo(pTitle, pDetail, pPriority) {
    this.title= pTitle;
    this.detail = pDetail;
    this.priority = pPriority;
  }
  var ClientToDos = [];  // don't really need this intermediate array, but if we want to allow
  // edits to existing ones, it would then be useful

document.addEventListener("DOMContentLoaded", function (event) {

    document.getElementById("submit").addEventListener("click", function () {
        var tTitle = document.getElementById("title").value;
        var tDetail = document.getElementById("detail").value;
        var tPriority = document.getElementById("priority").value;
        var oneToDo = new ToDo(tTitle, tDetail, tPriority);

        $.ajax({
            url: '/NewToDo' ,
            method: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(oneToDo),
            success: function (result) {
                console.log("added new note")
            }

        });
    });

    document.getElementById("get").addEventListener("click", function () {
        
        var listDiv = document.getElementById('listDiv');
        listDiv.innerHTML = "";  // clears existing list so we don't duplicate old ones
        
        var ul = document.createElement('ul')

        $.get("/ToDos", function(data, status){  // AJAX get
            ClientNotes = data;  // put the returned server json data into our local array
            listDiv.appendChild(ul);
            ClientNotes.forEach(ProcessOneToDo); // build one li for each item in array
            function ProcessOneToDo(item, index) {
                var li = document.createElement('li');
                ul.appendChild(li);
    
                li.innerHTML=li.innerHTML + index + ": " + " Priority: " + item.priority + "  " + item.title + ":  " + item.detail;
            }
        });
    });
  

    document.getElementById("delete").addEventListener("click", function () {
        
        var whichToDo = document.getElementById('deleteTitle').value;
        var idToDelete = "";
        for(i=0; i< ClientNotes.length; i++){
            if(ClientNotes[i].title === whichToDo) {
                idToDelete = ClientNotes[i]._id;
           }
        }
        
        if(idToDelete != "")
        {
                     $.ajax({  
                    url: 'DeleteToDo/'+ idToDelete,
                    type: 'DELETE',  
                    contentType: 'application/json',  
                    success: function (response) {  
                        console.log(response);  
                    },  
                    error: function () {  
                        console.log('Error in Operation');  
                    }  
                });  
            
        }
        else {
            console.log("no matching Subject");
        } 
    });
    
   
});

