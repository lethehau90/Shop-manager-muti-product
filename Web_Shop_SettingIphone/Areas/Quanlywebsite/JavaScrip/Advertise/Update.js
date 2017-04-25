function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Image: $("#TxtImage").val(),
        Width: "100",
        Height: "100",
        Link: $("#TxtLink").val(),
        Target: $('#SelectTarget>option:selected').val(),
        Content: CKEDITOR.instances['TxtContent'].getData(),
        Position: $('#SelectPosition>option:selected').val(),//vị trí quảng cáo trong trang
        PageId: $('#SelectPageId>option:selected').val(), //Loại Quảng cáo
        Click: "0",
        Ord: $("#TxtOrd").val(),
        Active: "",
        Lang: "vi",
        NameEn: $("#TxtNameEn").val(),
        ContentEn: CKEDITOR.instances['TxtContentEn'].getData(),
        Ngaytao: $("#datepickerNgaytao").val(),
        Ngayhethan: $("#datepickerNgayhethan").val(),
        LuotClick: "0"
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
    if (object.Ngaytao == "" || object.Ngaytao == null) {
        object.Ngaytao = Getdatetime(object.Ngaytao); //hàm trẻ về ngày tháng năm
    }
    if (object.Name == null || object.Name == "") {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    if (object.Image == null || object.Image == "") {
        var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
        $("#TxtImage").parent().append(html);
        flag = false;
    }
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrd").parent().append(html);
        flag = false;
    }
    //if (CKEDITOR.instances['TxtContent'].getData() == null || CKEDITOR.instances['TxtContent'].getData() == "") {
    //    var html = "<span  class='error'>Nội dung (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
    //    $(".TxtContent").parent().append(html);
    //    flag = false;
    //}
    if (object.PageId == null || object.PageId == "") {
        var html = "<span class='error'>Vị trí danh mục yêu cầu chọn</span>";
        $("#SelectPageId").parent().append(html);
        flag = false;
    }
    //if (object.Position == null || object.Position == "") {
    //    var html = "<span class='error'>Chọn vị trí ảnh yêu cầu chọn</span>";
    //    $("#SelectPosition").parent().append(html);
    //    flag = false;
    //}
    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/ImagesAdvertiseAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/ImagesAdvertiseAdmin/Read";
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