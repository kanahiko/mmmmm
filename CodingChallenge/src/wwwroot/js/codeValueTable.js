
$(document).ready(function () {
    loadCVTable("");
});


function loadCVTable(inputValue) {
    $.ajax({
        url: "/api/codevalues/" + inputValue,
        type:"GET"
    }).then(function (data) {
        $('#CV_table tbody').empty();
        $('#CV_table').append("<tr><th>ID</th><th>Код</th><th>Значение</th></tr>");        
        for (i = 0; i < data.length; i++) {
            $('#CV_table').append("<tr><th>" + data[i].id + "</th><th>" + data[i].code + "</th><th>" + data[i].value + "</th></tr>");
        }
    });
}


function addButtonClick() {
    $('#file_dialog').click();    
}

function fileSelect() {

    var file = $('#file_dialog').prop('files')[0];
    $('#file_dialog').val('');
    var fileText;
    const readeProjectTestsr = new FileReader();
    reader.addEventListener('load', (event) => {
        fileText = event.target.result;

        $.ajax({
            url: "/api/codevalues/",
            type: "POST",
            data: fileText,
            dataType: "json",
            error:function(XMLHttpRequest, textStatus, errorThrown) {
                if (XMLHttpRequest.status == 201) {
                    alert(XMLHttpRequest.responseText);
                    loadCVTable("");
                } else {
                    alert("Данные не загруженны. " + XMLHttpRequest.responseText);

                }
            }
        });
    });
    reader.readAsText(file);
}
