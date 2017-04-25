function Upadte_lever2() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtlevelId").val(),
        Thuoctinh: $("#TxtlevelName").val(),
        Idtinhang: $('#Selectlevel2muti_>option:selected').val(),//vị trí loại
        Title: "",
        Ord: $("#TxtlevelOrd").val(),
        Active: "",
        Content: $("#Txtlevelcontent").val(),
    };

    // console.log(object);
    // return false;
    // đưa giá trị actice chek
    var checkA = $("#CKTxtlevelActive:checked").val();
    if (checkA == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    if (object.Thuoctinh == null || object.Thuoctinh == "") {
        var html = "<span  class='error'>Tên danh mục yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtlevelName").parent().append(html);
        flag = false;
    }
    //if (object.Logogroup == null || object.Logogroup == "") {
    //    var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
    //    $("#TxtlevelLogogroup").parent().append(html);
    //    flag = false;
    //}
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtlevelOrd").parent().append(html);
        flag = false;
    }
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/DientuTinhnangAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/DientuTinhnangAdmin/Read";
                            }, 2000)
                           
                        }
                        else {
                            alert_name();
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