function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtId").val(),
        MenuName: $("#TxtName").val(),
        Tag: "",
        Level: $('#Selectlevel>option:selected').val(),//vị trí loại
        Logogroup: $("#TxtLogogroup").val(),
        Ord: $("#TxtOrd").val(),
        Active: "",
        Mota: $("#Txtcontent").val(),
        idThuoctinh: "0",//thuộc tính,
        Url: "",
        Priority: "",
        Description: $("#TxtDescription").val(),
        Keyword: $("#TxtKeyword").val(),
        Index: "0"
    };

    // console.log(object);
    // return false;
    // đưa giá trị actice chek
    var checkA = $("#CKActive:checked").val();
    var checkP = $("#CKPriority:checked").val();
    if (checkA == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }

    if (checkP == "1") {
        object.Priority = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Priority = 0; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.MenuName == null || object.MenuName == "") {
        var html = "<span  class='error'>Tên danh mục yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    //if (object.Logogroup == null || object.Logogroup == "") {
    //    var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
    //    $("#TxtLogogroup").parent().append(html);
    //    flag = false;
    //}
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrd").parent().append(html);
        flag = false;
    }
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/DientuMenuSitemathangAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/DientuMenuSitemathangAdmin/Read";
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