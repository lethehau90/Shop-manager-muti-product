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

    //$("#TxtImages").blur(function () { //sự kiện khi rời vị trí đối tượng
    //    $("#imgShowScren").attr("src", $("#TxtImages").val());
    //    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});

    //$("#imgShowScren").click(function () { // sự kiện khi click lên ảnh

    //    $("#imgShowScren").attr("src", $("#TxtImages").val()); // lấy ảnh giá trị biến Id
    //    var img = $("#imgShowScren").attr("src"); // lấy giá trị
    //    if (img == "" || img == null) { //nếu null
    //        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    //    }
    //});
    // end xử lý sự kiện hình ảnh

});

//load jaavscrip đầu vào
$("#update_paner").css("display", "none");

//soạn chỉnh sửa
$(".Edit").click(function () {
   
    var action = $(this); // khởi tạo hành động
    var Id = action.data('id');
    get_Read(Id); //gọi hàm get dữ liệu
    //star loading
    $("body").addClass("loading");
    setTimeout(function () {

        $("#update_paner").css("display", "block"); //hiển thị panner

        get_Read(Id); //gọi hàm get dữ liệu

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
        TxtOrd: $("#TxtOrd").val(),
        TxtContent: $("#TxtContent").val(),
        //TxtImages: $("#TxtImages").val(),
        CKActive: ""
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
        if (key == "TxtContent" || key == "TxtContent_En") {
            CKEDITOR.instances[key].setData(""); //set về rỗng
        }
    });
    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
    $("#TxtOrd").val("1");
    $("#CKActive").val("1");
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});

