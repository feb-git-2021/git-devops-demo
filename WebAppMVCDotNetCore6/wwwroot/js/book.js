
var dataTable;
//$(document).ready(() => {

//})

//OR
$(document).ready(function () {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Book/GetAll",
            
        },
        "columns": [

            { "data": "bookTitle", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "category.categoryName", "width": "15%" }
          
        ]

    });
   

})