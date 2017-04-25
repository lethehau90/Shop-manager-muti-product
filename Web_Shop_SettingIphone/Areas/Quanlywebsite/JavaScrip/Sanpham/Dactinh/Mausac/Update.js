function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        IDmau: $("#TxtId").val(),
        Tenmau: $("#TxtTenmau").val(),
        Hinhanh: $("#TxtImage").val(),
        Ord: $("#TxtOrd").val(),
        Active: "",
        Lang: "vi",
        TenmauEn: $("#TxtTenmauEn").val(),
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

    if (object.Tenmau == null || object.Tenmau == "") {
        var html = "<span  class='error'>Tên màu (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtTenmau").parent().append(html);
        flag = false;
    }
    if (object.Hinhanh == null || object.Hinhanh == "") {
        var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
        $("#TxtImage").parent().append(html);
        flag = false;
    }
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
                url: "/Quanlywebsite/MausacAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/MausacAdmin/Read";
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