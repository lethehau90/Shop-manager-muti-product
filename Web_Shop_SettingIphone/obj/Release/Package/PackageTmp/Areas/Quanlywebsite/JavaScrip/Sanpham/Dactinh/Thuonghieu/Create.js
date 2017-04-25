function Insert() {

    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //IDthuonghieu: $("#TxtId").val(),
        Tenthuonghieu: $("#TxtTenthuonghieu").val(),
        Logo: $("#TxtImage").val(),
        Url: $("#TxtUrl").val(),
        Active: "",
        Vitri: $("#TxtVitri").val(),
        Lienkettinh: "",
        mota: CKEDITOR.instances['Txtmota'].getData(),
        Lang: "vi",
        Tenthuonghieu_En: $("#TxtTenthuonghieu_En").val(),
        mota_En: CKEDITOR.instances['Txtmota_En'].getData()
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

    if (object.Tenthuonghieu == null || object.Tenthuonghieu == "") {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtTenthuonghieu").parent().append(html);
        flag = false;
    }
    //if (object.Logo == null || object.Logo == "") {
    //    var html = "<span  class='error'>Logo rỗng (không bỏ trống)</span>";
    //    $("#TxtImage").parent().append(html);
    //    flag = false;
    //}
    if (object.Vitri == null || object.Vitri == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtVitri").parent().append(html);
        flag = false;
    }

    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        //console.log(object); //bug lỗi
       // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/ThuonghieuAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/ThuonghieuAdmin/Read";
                            }, 2000)
                        }
                        else {
                            alert_name();
                            return false;
                        }
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
           
            $("body").removeClass("loading");
        }, 1000); //end loading
    }
    else {
        alert_question_libary();

    }
    return flag;

}