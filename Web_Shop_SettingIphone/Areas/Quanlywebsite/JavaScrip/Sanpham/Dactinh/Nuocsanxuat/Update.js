function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        IDthuonghieu: $("#TxtId").val(),
        TenNuocsanxuat: $("#TxtTenNuocsanxuat").val(),
        Logo: $("#TxtImage").val(),
        Active: "",
        Vitri: $("#TxtVitri").val(),
        TenNuocsanxuat_En: $("#TxtTenNuocsanxuat_En").val(),
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
   
    if (object.TenNuocsanxuat == null || object.TenNuocsanxuat == "") {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtTenNuocsanxuat").parent().append(html);
        flag = false;
    }
    
    if (object.Vitri == null || object.Vitri == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtVitri").parent().append(html);
        flag = false;
    }
    
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/NuocsanxuatAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/NuocsanxuatAdmin/Read";
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