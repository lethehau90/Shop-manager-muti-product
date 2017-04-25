function Insert() {
    var filter = window.location.search.substring(1); //lấy giá trị request url
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Tag: $("#TxtTag").val(),
        Image: $("#TxtImage").val(),
        Content: $("#TxtContent").val(),
        Detail: CKEDITOR.instances['TxtDetail'].getData(),
        Date: "",
        Title: "",
        Description: $("#TxtDescription").val(),
        Keyword: $("#TxtKeyword").val(),
        Priority: $('#SelectPriority>option:selected').val(),//vị trí loại
        Index: "1",
        Active: "",
        ord: $("#Txtord").val(),
        Nguon: $('#TxtNguon').val(), //Loại Quảng cáo
        Lang: "vi",

        Image1: $("#TxtImage1").val(),
        Image2: $("#TxtImage2").val(),
        Image3: $("#TxtImage3").val(),
        Image4: $("#TxtImage4").val(),
        Image5: $("#TxtImage5").val(),

        GroupNewsCatTag: $('#SelectCategory>option:selected').val(),//id danh mục
        Cateprolevel1: "",
        Cateprolevel2: "",
        Cateprolevel3: "",
      
        NameEn: $('#TxtNameEn').val(),
        ContentEn: $('#TxtContentEn').val(),
        DetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),
        DateView: "",
        Luotxem: "0"
       
    };

     console.log(object);
    // return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = 0; //gán giá trị 0 (false) không kích hoạt
    }
    if (object.Name == null || object.Name == "") {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    if (object.Content == null || object.Content == "") {
        var html = "<span  class='error'>mô tả bài viết (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtContent").parent().append(html);
        flag = false;
    }
    if (CKEDITOR.instances['TxtDetail'].getData() == null || CKEDITOR.instances['TxtDetail'].getData() == "") {
        var html = "<span  class='error'>Chi tiết nội dung (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtDetail").parent().append(html);
        flag = false;
    }
    if (object.ord == null || object.ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#Txtord").parent().append(html);
        flag = false;
    }
    if (object.GroupNewsCatTag == null || object.GroupNewsCatTag == "") {
        var html = "<span  class='error'></br> Danh mục chưa được chọn</span>";
        $("#SelectCategory").parent().append(html);
        flag = false;
    }
    if (object.Image == null || object.Image == "") {
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
                url: "/Quanlywebsite/CategoryNewsDetailsAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/CategoryNewsDetailsAdmin/Read?" + filter;
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