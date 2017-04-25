function Insert() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //Id: $("#TxtId").val(),
        Name: $("#TxtName").val(),
        NameEn: $("#TxtNameEn").val(),
        content: CKEDITOR.instances['Txtcontent'].getData(),
        contentEn: CKEDITOR.instances['TxtcontentEn'].getData(),
        Ord: $("#TxtOrd").val(),
        Active: "",
        Date_event_start: $("#Date_event_start").val(),
        Date_event_end: $("#Date_event_end").val(),
        Price_event: $("#TxtPrice_event").val()
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

    if (object.Ord == null || object.Ord == "") {
        var html = "<span  class='error'></br> Số thứ tự (không bỏ trống)</span>";
        $("#TxtOrd").parent().append(html);
        flag = false;
    }

    if (object.Price_event == null || object.Price_event == "") {
        var html = "<span  class='error'>Tỉ lệ % giảm  (không bỏ trống)</span>";
        $(".TxtPrice_event").parent().append(html);
        flag = false;
    }

    if (object.Date_event_start == null || object.Date_event_start == "") {
        var html = "<span  class='error'></br> Ngày sự kiện bắt đầu (không bỏ trống)</span>";
        $("#Date_event_start").parent().append(html);
        flag = false;
    }

    if (object.Date_event_end == null || object.Date_event_end == "") {
        var html = "<span  class='error'></br> Ngày sự kiện kết thúc (không bỏ trống)</span>";
        $("#Date_event_end").parent().append(html);
        flag = false;
    }
    //if (CKEDITOR.instances['Txtcontent'].getData() == null || CKEDITOR.instances['Txtcontent'].getData() == "") {
    //    var html = "<span  class='error'>Nội dung (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
    //    $(".Txtcontent").parent().append(html);
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
                url: "/Quanlywebsite/KM_SukienDateAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/KM_SukienDateAdmin/Read";
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