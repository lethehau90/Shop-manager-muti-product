$(document).ready(function () {

    $('.Delete').click(function () {
        var action = $(this); // khởi tạo hành động hiện tại
        $.jAlert({
            'type': 'confirm', 'confirmQuestion': 'Bạn xác nhận xóa ?', 'onConfirm': function () {
                var Id = action.data('id');
                //star loading
                $("body").addClass("loading");
                setTimeout(function () {
                    //star xử lý hàm ajax ở đây
                    $.ajax({
                        url: "/Quanlywebsite/UserAdmin/Deleteone",
                        type: "Post",
                        data: { Id: Id },
                        datatype: "json",
                        success: function (data) {
                            if(data==1)
                            {
                                location.href = "/Quanlywebsite/UserAdmin/Read";
                            }
                            else
                            {
                                alert_Role();
                            }
                        },
                        error: function (err) {
                            alert("Error:" + err.responseText);
                        }
                    });
                    //end xử lý hàm ajax ở đây
                    $("body").removeClass("loading");
                }, 500);
            }, 'onDeny': function () {
                return false;
            }
        });
    });
});