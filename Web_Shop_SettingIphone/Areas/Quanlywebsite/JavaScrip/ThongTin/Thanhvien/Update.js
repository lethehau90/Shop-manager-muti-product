function Upadte() {
    var url = window.location.href;
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        id:$("#TxtId").val(),
        Taikhoan: $("#TxtTaikhoan").val(),
        Matkhau: $("#TxtMatkhau").val(),
        Hoten: $("#TxtHoten").val(),
        Ngaysinh: $("#datepickerNgaysinh").val(),
        Gioitinh: $('#SelectGioitinh>option:selected').val(),
        Diachi: $("#TxtDiachi").val(),
        SDT: $("#TxtSDT").val(),
        Email: $("#TxtEmail").val(),
        Actice: ""
     
    };
    
    // console.log(object);
    // return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "true") {
        object.Actice = "true"; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Actice = "false"; //gán giá trị 0 (false) không kích hoạt
    }

  
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/ThanhvienAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = url;
                            }, 2000)
                           
                        }
                        else {
                            alert_email();
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