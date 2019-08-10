var Order = {
    url: "http://localhost:40214/"
}

document.addEventListener('DOMContentLoaded', function () {
    loaduser();
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
    if (usid > 0) {
        $.ajax({
            url: Order.url + 'Order/OrderNow',
            data: {
                UserId: usid,
                menu: MenuModelID
            },
            dataType: 'json',
            type: 'post',
            success: function (data) {
                alert('data' + data);
            }
        });
    }
    else {
        alert("Select the user");
        $('#user').show();
    }
        
}