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
                        url: "/Quanlywebsite/SlideShowAdmin/Deleteone",
                        type: "Post",
                        data: { Id: Id },
                        datatype: "json",
                        success: function (data) {
                            if(data==1)
                            {
                                location.href = "/Quanlywebsite/SlideShowAdmin/Read";
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

///code xử lý cho xóa nhiều dòng dữ liệu

$(document).ready(function () {
    function senddell() {


        $.jAlert({
            'type': 'confirm', 'confirmQuestion': 'Bạn xác nhận xóa ?', 'onConfirm': function () {

                //code xử lý ở đây

                var id = [];
                $(".dell:checked").each(function () {
                    var v = $(this).attr("index");
                    id.push(v);
                });
                if (id.length > 0) {

                        $("body").addClass("loading");
                        setTimeout(function () {

                            $.ajax({
                                type: "Post",
                                dataType: "json",
                                contentType: 'application/json; charset=utf-8',
                                url: "/Quanlywebsite/SlideShowAdmin/DeleteAll",
                                data: JSON.stringify(id),
                                success: function (data) {

                                    if (data == 1) {
                                        location.href = "/Quanlywebsite/SlideShowAdmin/Read";
                                    }
                                    else {
                                        alert_Role();
                                    }

                                    //window.location = "/ManagePclient/ListPclient";
                                }
                            });
                            $("body").removeClass("loading");
                        }, 2000);
                    
                }
                else {
                    alert_Detenone();
                }


                //end code xư lý ở đâ



            }, 'onDeny': function () {
                return false;

            }
        });
     
    }

    ///lệnh nhấn delete
    $("#Deleteall").click(function () {
        senddell();
    });
});


