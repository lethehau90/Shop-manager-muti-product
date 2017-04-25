function Upadte() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = {
            Id: $("#TxtId").val(),
            Name:  $("#TxtName").val(),
            Image: $("#TxtImage").val(),
            Target:"",
            Content: "",
            Detail: CKEDITOR.instances['TxtDetail'].getData(),
            Position: "0",
            Click: "0",
            Ord: "1",
            Active: "",
            Lang: "vi",
            Title:"",
            Description: $("#TxtDescription").val(),
            Keyword: $("#TxtKeyword").val(),
            Image1: "",
            Image2: "",
            Image3: "",
            Image4: "",
            Image5: "",
            Index: "1", //set vị trí tin trang chủ
            Priority: "1",
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
    if (object.Detail == "") {
        var html = "<span style='color:red; padding-left:5px' class='error'>Vui lòng nhập trường này (tiếng việt mặc định)</span>";
        $(".TxtDetail").after(html); //xuất html phái sau text
        flag = false;
    }

    if (flag == true) { //trạng thái đúng bắt đầu xử lý
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            $("body").removeClass("loading");
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/NewInformationAdmin/Update",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_update(); //thông báo
                            window.setTimeout(function () {
                              
                                location.href = "/Quanlywebsite/NewInformationAdmin/Read";
                               
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