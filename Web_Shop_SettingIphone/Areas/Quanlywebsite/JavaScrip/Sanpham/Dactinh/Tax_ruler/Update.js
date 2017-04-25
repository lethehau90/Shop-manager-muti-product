function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Province: $("#TxtProvince").val(),
        Tax_pri: $("#TxtTax_pri").val(),
        Description: CKEDITOR.instances['TxtDescription'].getData(),
        File_tax: $("#TxtFile_tax").val(),
        Ord: $("#TxtOrd").val(),
        Active: "",
        NameEn: $("#TxtNameEn").val(),
        DescriptionEn: CKEDITOR.instances['TxtDescriptionEn'].getData()
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

    if (object.Name == null || object.Name == "") {
        var html = "<span  class='error'>Danh mục thuế (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    if (object.Province == null || object.Province == "") {
        var html = "<span  class='error'>Khu vực thuế  yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtProvince").parent().append(html);
        flag = false;
    }
    if (object.Tax_pri == null || object.Tax_pri == "") {
        var html = "<span  class='error'>Phần trăm thuế yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtTax_pri").append(html);
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
                url: "/Quanlywebsite/Tax_rulerAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/Tax_rulerAdmin/Read";
                            }, 2000)
                           
                        }
                        else {
                            alert_tax();
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