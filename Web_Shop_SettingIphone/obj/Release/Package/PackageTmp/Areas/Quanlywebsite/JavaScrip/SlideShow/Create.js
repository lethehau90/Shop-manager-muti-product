function Insert() {

    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Image: $("#TxtImage").val(),
        Width: "100",
        Height: "100",
        Link: $("#TxtLink").val(),
        Target: $('#SelectTarget>option:selected').val(),
        Content: "",
        Position: "0",
        Click: "0",
        Ord: $("#TxtOrd").val(),
        Active: "",
        Lang: "vi",
        Detail: CKEDITOR.instances['TxtDetail'].getData(),
        Title:"",
        Description: $("#TxtDescription").val(),
        Keyword: $("#TxtKeyword").val(),
        Image1: "",
        Image2: "",
        Image3: "",
        Image4: "",
        Image5: "",
        Index: "1", //set vị trí tin trang chủ
        Priority: "0",
        Tag: "",
        NameEn: $("#TxtNameEn").val(),
        ContentEn: "",
        DetailEn: CKEDITOR.instances['TxtDetailEn'].getData()  //get dữ liệu ckeditor
    };

    var check = $("#CKActive:checked").val();
    if (check == true) {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    // console.log(object);

    if (object.Name == "") {
        var html = "<span style='color:red' class='error'>Vui lòng nhập trường này (tiếng việt mặc định)</span>";
        $("#TxtName").parent().append(html); //xuất html phái sau text
        flag = false;
    }
    if (object.Image == "") {
        var html = "<span style='color:red' class='error'>Vui lòng chọn ảnh</span>";
        $("#TxtImage").parent().append(html); //xuất html phái sau text
        flag = false;
    }
    //if (object.Detail == "") {
    //    var html = "<span style='color:red; padding-left:5px' class='error'>Vui lòng nhập trường này (tiếng việt mặc định)</span>";
    //    $(".TxtDetail").after(html); //xuất html phái sau text
    //    flag = false;
    //}

    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        //console.log(object); //bug lỗi
        // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/SlideShowAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/SlideShowAdmin/Read";
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
        }, 1000); //end loading
    }
    else {
        alert_question_libary();

    }
    return flag;

}