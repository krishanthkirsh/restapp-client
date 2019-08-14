var Order = {
    url: "http://localhost:40214/" 
}

document.addEventListener('DOMContentLoaded', function () {
    //loaduser();
    var usid = sessionStorage.getItem("UserId");
    (usid > 0) ? $('#user').hide() : $('#user').show();

    $("#userSelection").change(function () {
        userid = $("#userSelection").val();
        sessionStorage.setItem("UserId", userid);
        $('#user').hide();
    });
}, false);


var loaduser = function () {
    $.ajax({
        url: Order.url + 'User/GetUserListAsync',
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

var OrderNow = function (MenuModelID) {
    var usid = sessionStorage.getItem("UserId");
    var current_datetime = new Date();
    var formatted_date = current_datetime.getDate() + '/' + (current_datetime.getMonth() + 1) + '/' + current_datetime.getFullYear() + '-' + current_datetime.getMinutes() + ':' + current_datetime.getSeconds();
    if (usid > 0) {
        $.ajax({
            url: Order.url + 'Order/OrderNow',
            data: {
                UserId: usid,
                menu: MenuModelID,
                Date: formatted_date
            },
            dataType: 'json',
            type: 'POST',
            success: function (data) {
                alert(data);
            },
            error: function (data) {
                alert('error' + data);
            },
            async: false
        });
    }
    else {
        alert("Select the user");
        $('#user').show();
    }
        
}