function Insert() {
    
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        Tag: "",
        Level: $('#Selectlevel>option:selected').val(),//vị trí loại
        Title: "",
        Description: $("#TxtDescription").val(),
        Keyword: $("#TxtKeyword").val(),
        Ord: $("#TxtOrd").val(),
        Priority: "",
        Index: "0",
        Active: "",
        Lang: "vi",
        Logogroup: $("#TxtLogogroup").val(),
        NameEn: $("#TxtNameEn").val(),
        TitleEn: "",
        ImagesLogo: "",
        content: $("#Txtcontent").val(),
        contentEn: $("#TxtcontentEn").val(),
        Level2: $('#Selectlevelmuti>option:selected').val()//vị trí loại
    };

   // console.log(object);
   // return false;
    // đưa giá trị actice chek
    var checkA = $("#CKActive:checked").val();
    var checkP = $("#CKPriority:checked").val();
    if (checkA == "1") {
        object.Active = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = 0; //gán giá trị 0 (false) không kích hoạt
    }

    if (checkP == "1") {
        object.Priority = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Priority = 0; //gán giá trị 0 (false) không kích hoạt
    }
    
    if (object.Name == null || object.Name == "")
    {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtName").parent().append(html);
        flag = false;
    }
    //if (object.Logogroup == null || object.Logogroup == "") {
    //    var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
    //    $("#TxtLogogroup").parent().append(html);
    //    flag = false;
    //}
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrd").parent().append(html);
        flag = false;
    }
   
    console.log(object);
    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
       // console.log(object); //bug lỗi
       // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/CategoryNewsAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/CategoryNewsAdmin/Read";
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

//thêm mới cấp độ 2
function Insert_lever2() {

    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //Id: $("#TxtId").val(),
        Name: $("#TxtaddName").val(),
        Tag: "",
        Level: $('#Selectlevel_add>option:selected').val(),//vị trí loại
        Title: "",
        Description: $("#TxtaddDescription").val(),
        Keyword: $("#TxtaddKeyword").val(),
        Ord: $("#TxtaddOrd").val(),
        Priority: "",
        Index: "0",
        Active: "",
        Lang: "vi",
        Logogroup: $("#TxtaddLogogroup").val(),
        NameEn: $("#TxtaddNameEn").val(),
        TitleEn: "",
        ImagesLogo: "",
        content: $("#Txtaddcontent").val(),
        contentEn: $("#TxtaddcontentEn").val(),
        Level2: $('#Selectlevelmuti>option:selected').val()//vị trí loại
    };

    // return false;
    // đưa giá trị actice chek
    var checkA = $("#CKaddActive:checked").val();
    var checkP = $("#CKaddPriority:checked").val();
    if (checkA == "1") {
        object.Active = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = 0; //gán giá trị 0 (false) không kích hoạt
    }

    if (checkP == "1") {
        object.Priority = 1; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Priority = 0; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.Name == null || object.Name == "") {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtaddName").parent().append(html);
        flag = false;
    }
    //if (object.Logogroup == null || object.Logogroup == "") {
    //    var html = "<span  class='error'>hình ảnh rỗng (không bỏ trống)</span>";
    //    $("#TxtaddLogogroup").parent().append(html);
    //    flag = false;
    //}
    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtaddOrd").parent().append(html);
        flag = false;
    }

    console.log(object);
    if (flag == true) //trang thái đúng bắt đầu xử lý
    {
        // console.log(object); //bug lỗi
        // return false;
        //star loading
        $("body").addClass("loading");
        setTimeout(function () {
            //star xử lý hàm ajax ở đây
            $.ajax({
                url: "/Quanlywebsite/CategoryNewsAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/CategoryNewsAdmin/Read";
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