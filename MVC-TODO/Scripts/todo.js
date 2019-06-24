function amendmodel(index) {

    var keep = document.getElementById("complete" + index.toString());

    var action = '/Home/AmendCompleteTask';

    $.ajax({
        url: action,
        type: 'POST',
        data: {
            itemID: index,
            isComplete: keep.checked
        },
        dataType: " text json",
        success: function (data) {

            var isCompleteID = "complete" + index.toString();
            var todoListItem = "text" + index.toString();

            if (document.getElementById(isCompleteID).checked) {
                document.getElementById(todoListItem).style.textDecoration = "line-through";
            }
            else {
                document.getElementById(todoListItem).style.textDecoration = "none";
            }
           
            var checked = document.querySelectorAll('input:checked');
            var checkboxes = document.querySelectorAll('input[type="checkbox"]');

            $('#messageBlock').load('/Home/MessageReset');

            // No well done for completeing less than 3 tasks!
            if (checkboxes.length > 2) {
                if (checked.length === checkboxes.length) {
                    $('#messageBlock').load('/Home/CongratsMessage');
                }
            }
         
        },
        error: function () {
            alert("Error: In todo.js call");
        }
    });
}