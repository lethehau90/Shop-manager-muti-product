function Insert() {
    
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống
        //Id: $("#TxtId").val(),
        Thuoctinh: $("#TxtName").val(),
        Idtinhang: $('#Selectlevel>option:selected').val(),//vị trí loại
        Title: "",
        Ord: $("#TxtOrd").val(),
        Active: "",
        Content: $("#Txtcontent").val(),
        Level2: $('#Selectlevelmuti>option:selected').val()//vị trí loại
    };

   // console.log(object);
   // return false;
    // đưa giá trị actice chek
    var checkA = $("#CKActive:checked").val();
    if (checkA == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }
    
    if (object.Thuoctinh == null || object.Thuoctinh == "")
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
                url: "/Quanlywebsite/DientuTinhnangAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/DientuTinhnangAdmin/Read";
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
        Thuoctinh: $("#TxtaddName").val(),
        Idtinhang: $('#Selectlevel_add>option:selected').val(),//vị trí loại
        Title: "",
        Ord: $("#TxtaddOrd").val(),
        Active: "",
        Content: $("#Txtaddcontent").val(),
        Level2: $('#Selectlevelmuti>option:selected').val()//vị trí loại
    };

    // return false;
    // đưa giá trị actice chek
    var checkA = $("#CKaddActive:checked").val();
    if (checkA == "1") {
        object.Active = true; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = false; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.Thuoctinh == null || object.Thuoctinh == "") {
        var html = "<span  class='error'>Tên danh mục yêu cầu nhập (không bỏ trống)</span>";
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
                url: "/Quanlywebsite/DientuTinhnangAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if (data == 1 || data == 0) {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/DientuTinhnangAdmin/Read";
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