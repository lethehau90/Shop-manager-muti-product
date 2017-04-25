function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = {
        Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Username: $("#TxtUsername").val(),
        Password: $("#TxtPassword").val(),
        ConfirmPassword: $("#TxtConfirmPassword").val(),
        Ord: $("#TxtOrd").val(),
        Role: $('#SelectRole>option:selected').val(),
        Active: ""
    };
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = "1"; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = "0"; //gán giá trị 0 (false) không kích hoạt
    }

    

    if (object.Id == "") {
        alert_Error_ID();
        flag = false;
    }

    $.each(object, function (key, item) { //lặp key xử lý

        if (item == "") // kiểm tra dữ liệu đầu vào
        {
            var html = "<span style='color:red' class='error'>Vui lòng nhập trường này</span>";
            $("#Txt" + key).parent().append(html); //xuất html phái sau text
            flag = false;
        }
        else if (key == "ConfirmPassword") //kiểm tra nhập khớp pass
        {
            if (object.Password != object.ConfirmPassword) {
                var html = "<span style='color:blue' class='error'>Mật khẩu xác nhận lại không chính xác </span>";
                $("#Txt" + key).parent().append(html);
                $("#Txt" + key).val("");
                flag = false;
            }
        }
    });
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/UserAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/UserAdmin/Read";
                            }, 2000)
                           
                        }
                        else {
                            alert_name_user();
                            return false;
                        }
                    }
                    else {
                        alert_Role();
                    }
                },
                error: function (err) {
                    alert("Error:" + err.responseText);
                }
            });

            $("body").removeClass("loading");
        }, 1000);
    }
    else {
        alert_question_libary();

    }
    return flag;

}