function Insert() {
    $(".error").remove(); //xóa class báo lỗi vailform inut
    var flag = true; //trạng thái
    //khai báo đối tượng
    var object = { //khai báo các giá trị xóa trống

        type: $('#SelectType>option:selected').val(),
        Active: "",
        Lang: "vi",
        Ten: $("#TxtTen").val(),
        Html_content: CKEDITOR.instances['TxtHtmlcontent'].getData(),
        TenEn: $("#TxtTenEn").val(),
        Html_contentEn: CKEDITOR.instances['TxtHtmlcontentEn'].getData(),
        images: $("#Txtimages").val(),
        Ord: $("#TxtOrd").val()
    };

   // console.log(object);
   // return false;
    // đưa giá trị actice chek
    var check = $("#CKActive:checked").val();
    if (check == "1") {
        object.Active = "1"; //gán giá trị 1 (true) có kích hoạt
    }
    else {
        object.Active = "0"; //gán giá trị 0 (false) không kích hoạt
    }

    if (object.Ten == null || object.Ten == "")
    {
        var html = "<span  class='error'>Tên danh mục (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $("#TxtTen").parent().append(html);
        flag = false;
    }
    if (CKEDITOR.instances['TxtHtmlcontent'].getData() == null || CKEDITOR.instances['TxtHtmlcontent'].getData() == "") {
        var html = "<span  class='error'>Nội dung (tiếng việt mặc định) yêu cầu nhập (không bỏ trống)</span>";
        $(".TxtHtmlcontent").parent().append(html);
        flag = false;
    }
    if (object.type == null || object.type == "") {
        var html = "<span class='error'>Danh mục chọn yêu cầu chọn</span>";
        $("#SelectType").parent().append(html);
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
                url: "/Quanlywebsite/CodeHtmlAdmin/Insert",
                type: "Post",
                data: object,
                datatype: "json",
                success: function (data) {
                    if(data ==1 || data ==0)
                    {
                        if (data == 1) {
                            alert_Insert(); //thông báo
                            window.setTimeout(function () {
                                location.href = "/Quanlywebsite/CodeHtmlAdmin/Read";
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