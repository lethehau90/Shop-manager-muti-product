function Insert() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Tag: $("#TxtTag").val(),
        Ngaydang: "",
        Tomtat: $("#TxtTomtat").val(),
        Noidung: CKEDITOR.instances['TxtNoidung'].getData(),
        Tacgia: $("#TxtTacgia").val(),
        Luotxem: "0",
        Hinhanh: $("#TxtImage").val(),
        Title: "",
        Description: $("#TxtDescription").val(),
        Keyword: $("#TxtKeyword").val(),
        Active: "",
        Ord: $("#TxtOrd").val(),
        Type: $('#SelectType>option:selected').val(),//vị trí loại
        Ngayxemganday: "",
        lienkiettinh: "",
        NameEn: $('#TxtNameEn').val(),
        ContentEn: $('#TxtContentEn').val(),
        DetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),
        Nguon: $('#TxtNguon').val(), //Loại Quảng cáo
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
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    if (object.Tomtat == null || object.Tomtat == "") {
        var html = "<span  class='error'>mô tả bài viết (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtTomtat").parent().append(html);
        flag = false;
    }
    if (CKEDITOR.instances['TxtNoidung'].getData() == null || CKEDITOR.instances['TxtNoidung'].getData() == "") {
        var html = "<span  class='error'>Chi tiết nội dung (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtNoidung").parent().append(html);
        flag = false;
    }
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrd").parent().append(html);
        flag = false;
    }
    if (object.Hinhanh == null || object.Hinhanh == "") {
        var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
        $("#TxtImage").parent().append(html);
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
                url: "/Quanlywebsite/TinTucAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/TinTucAdmin/Read?" + filter;
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