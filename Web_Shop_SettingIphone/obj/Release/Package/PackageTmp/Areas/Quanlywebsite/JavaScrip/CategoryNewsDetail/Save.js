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

    //xử lý sự kiện CKdisabled
    $("#CKdisabled").click(function () {
        if ($("#SelectCategory").attr("disabled") == "disabled") {
            $("#SelectCategory").removeAttr('disabled');
        }
        else
        {
            $("#SelectCategory").attr('disabled', 'disabled');
        }
           // return false;
    });

    //process event photo main
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
    //process event photo SliedesShow 1
    $("#TxtImage1").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren1").attr("src", $("#TxtImage1").val());
        var img = $("#imgShowScren1").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren1").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    $("#imgShowScren1").click(function () { // sự kiện khi click lên ảnh
        $("#imgShowScren1").attr("src", $("#TxtImage1").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren1").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren1").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    //process event photo SliedesShow 2
    $("#TxtImage2").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren2").attr("src", $("#TxtImage2").val());
        var img = $("#imgShowScren2").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren2").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    $("#imgShowScren2").click(function () { // sự kiện khi click lên ảnh
        $("#imgShowScren2").attr("src", $("#TxtImage2").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren2").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren2").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    //process event photo SliedesShow 3
    $("#TxtImage3").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren3").attr("src", $("#TxtImage3").val());
        var img = $("#imgShowScren3").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren3").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    $("#imgShowScren3").click(function () { // sự kiện khi click lên ảnh
        $("#imgShowScren3").attr("src", $("#TxtImage3").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren3").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren3").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    //process event photo SliedesShow 4
    $("#TxtImage4").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren4").attr("src", $("#TxtImage4").val());
        var img = $("#imgShowScren4").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren4").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    $("#imgShowScren4").click(function () { // sự kiện khi click lên ảnh
        $("#imgShowScren4").attr("src", $("#TxtImage4").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren4").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren4").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    //process event photo SliedesShow 5
    $("#TxtImage5").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren5").attr("src", $("#TxtImage5").val());
        var img = $("#imgShowScren5").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren5").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    $("#imgShowScren5").click(function () { // sự kiện khi click lên ảnh
        $("#imgShowScren5").attr("src", $("#TxtImage5").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren5").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren5").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });

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
//soạn chỉnh sửa
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

        TxtContent: $("#TxtContent").val(),
        TxtDetail: CKEDITOR.instances['TxtDetail'].getData(),

        TxtContentEn: $("#TxtContentEn").val(),
        TxtDetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),

        TxtNguon: $("#TxtNguon").val(),

        TxtDescription: $("#TxtDescription").val(),
        TxtKeyword: $("#TxtKeyword").val(),
        
        TxtImage: $("#TxtImage").val(),
        TxtImage1: $("#TxtImage1").val(),
        TxtImage2: $("#TxtImage2").val(),
        TxtImage3: $("#TxtImage3").val(),
        TxtImage4: $("#TxtImage4").val(),
        TxtImage5: $("#TxtImage5").val(),
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
        if (key == "TxtDetail" || key == "TxtDetailEn")
        {
            CKEDITOR.instances[key].setData(""); //set về rỗng
        }
    });

    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load photo main
    $("#imgShowScren1").attr("src", "/images/no-image.jpg");// load photo SlidesShow 1
    $("#imgShowScren2").attr("src", "/images/no-image.jpg");// load photo SlidesShow 2 
    $("#imgShowScren3").attr("src", "/images/no-image.jpg");// load photo SlidesShow 3
    $("#imgShowScren4").attr("src", "/images/no-image.jpg");// load photo SlidesShow 4
    $("#imgShowScren5").attr("src", "/images/no-image.jpg");// load photo SlidesShow 5

    $("#Txtord").val("1");
    $("#CKActive").val("1");

    $('#SelectPriority option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
    $('#SelectCategory option').removeAttr('selected').filter('[value=""]').attr('selected', true);
  
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});

//load jaavscrip đầu vào
$("#update_paner").css("display", "none");


