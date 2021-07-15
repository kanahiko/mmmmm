var CV_table;
$(document).ready(function () {
    loadCVTable();
});

function loadCVTable() {
    dataTable = $('#CV_table').DataTable({
        "ajax": {
            "url": "/api/values",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "index" },
            { "data": "code" },
            { "data": "value" }
        ]  
        
    });
}