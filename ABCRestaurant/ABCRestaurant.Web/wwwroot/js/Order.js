document.addEventListener('DOMContentLoaded', function () {
    loaduser();
    var usid = sessionStorage.getItem("UserId");
    if (usid > 0)
        $('#user').hide();
    else
        $('#user').show();

    $("#userSelection").change(function () {
        userid = $("#userSelection").val();
        sessionStorage.setItem("UserId", userid);
        $('#user').hide();
    });
}, false);


var loaduser = function () {
    console.log("Function Is called");

    $.ajax({
        url: 'http://localhost:40214/User/GetUserListAsync',
        dataType: 'json',
        type: 'Get',
        success: function (data) {
            $.each(data, function () {
                var option = $('<option>').attr('value', this.id).html(this.userName);
                $('#userSelection').append(option);
            });
        },
        async: false
    });
}

var OrderNow = function () {
    var usid = sessionStorage.getItem("UserId");
    if (usid > 0) {

    }
    else {
        alert("Select the user");
        $('#user').show();
    }
        
}