function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        ID: $("#TxtId").val(),
        Macode: $("#TxtMacode").val(),
        Valueprice: $("#TxtValueprice").val(),
        Active: "",
    };

    // console.log(object);
    // return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.Macode == null || object.Macode == "") {
        var html = "<span  class='error'>Tên chi phí dịch vụ (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtMacode").parent().append(html);
        flag = false;
    }
    if (object.Valueprice == null || object.Valueprice == "") {
        var html = "<span  class='error'>Phí dịch vụ rỗng (không bỏ trống)</span>";
        $(".TxtValueprice").parent().append(html);
        flag = false;
    }

    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/MacodeKhuyenMaiAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/MacodeKhuyenMaiAdmin/Read";
                            }, 2000)
                           
                        }
                        else {
                            alert_Macode();
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