function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        ID: $("#TxtId").val(),
        Kichco_Size: $("#TxtKichco_Size").val(),
        Ord: $("#TxtOrd").val(),
        Active: "",
        Lang: "vi",
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

    if (object.Kichco_Size == null || object.Kichco_Size == "") {
        var html = "<span  class='error'>Tên Kích cỡ - Size yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtKichco_Size").parent().append(html);
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
                url: "/Quanlywebsite/Kichco_SizeAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/Kichco_SizeAdmin/Read";
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