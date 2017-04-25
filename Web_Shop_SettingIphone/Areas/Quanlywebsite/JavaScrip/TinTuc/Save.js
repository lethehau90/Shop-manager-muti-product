$(document).ready(function () {
   
    $("#Save").click(function () { // khi nhấn lệnh lưu
        //xóa thông tin header

        var Id = $("#TxtId").val();
        if (Id == "")
        {
            Insert();
        }
        else
        {
            Upadte();
        }
        return false;
    });

    //xử lý sự kiện hình ảnh

    $("#TxtImage").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren").attr("src", $("#TxtImage").val());
        var img = $("#imgShowScren").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });

    $("#imgShowScren").click(function () { // sự kiện khi click lên ảnh

        $("#imgShowScren").attr("src", $("#TxtImage").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    // end xử lý sự kiện hình ảnh

});

//soạn chỉnh sửa
$(".Edit").click(function () {
   
    var action = $(this); // khởi tạo hành động
    var Id = action.data('id');
    get_Read(Id); //gọi hàm get dữ liệu
    //star loading
    $("body").addClass("loading");
    setTimeout(function () {

        $("#update_paner").css("display", "block"); //hiển thị panner

       // get_Read(Id); //gọi hàm get dữ liệu

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);

        $("body").removeClass("loading");  //end loading

    }, 500);


    return false;

});
//Copy
$(".Copy").click(function () {

    var action = $(this); // khởi tạo hành động
    var Id = action.data('id');
    get_Copy(Id); //gọi hàm get dữ liệu
    //star loading
    $("body").addClass("loading");
    setTimeout(function () {

        $("#update_paner").css("display", "block"); //hiển thị panner

        // get_Read(Id); //gọi hàm get dữ liệu

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);

        $("body").removeClass("loading");  //end loading

    }, 500);


    return false;

});

//thêm dữ liệu
$("#Insert").click(function () {
    $("span.Editcatelog").text("mới");
    $("#update_paner").css("display", "block");//hiển thị panner

    var object = { //khai báo các giá trị xóa trống
        TxtId: $("#TxtId").val(),
        TxtName: $("#TxtName").val(),
        TxtNameEn: $("#TxtNameEn").val(),

        TxtTomtat: $("#TxtTomtat").val(),
        TxtNoidung: CKEDITOR.instances['TxtNoidung'].getData(),

        TxtContentEn: $("#TxtContentEn").val(),
        TxtDetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),

        TxtNguon: $("#TxtNguon").val(),

        TxtDescription: $("#TxtDescription").val(),
        TxtKeyword: $("#TxtKeyword").val(),
        
        TxtImage: $("#TxtImage").val(),
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
        if (key == "TxtNoidung" || key == "TxtDetailEn")
        {
            CKEDITOR.instances[key].setData(""); //set về rỗng
        }
    });

    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định

    $("#TxtOrd").val("1");
    $("#CKActive").val("1");

    $('#SelectType option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
  
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});

//load jaavscrip đầu vào
$("#update_paner").css("display", "none");


