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
    $("#TxtImageCH").blur(function () { //sự kiện khi rời vị trí đối tượng
        $("#imgShowScren").attr("src", $("#TxtImageCH").val());
        var img = $("#imgShowScren").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    $("#imgShowScren").click(function () { // sự kiện khi click lên ảnh
        $("#imgShowScren").attr("src", $("#TxtImageCH").val()); // lấy ảnh giá trị biến Id
        var img = $("#imgShowScren").attr("src"); // lấy giá trị
        if (img == "" || img == null) { //nếu null
            $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        }
    });
    

});

//soạn chỉnh sửa
$(".Edit").click(function () {
   
    var action = $(this); // khởi tạo hành động
    var Id = action.data('id');
    get_Read(Id); //gọi hàm get dữ liệu

    // start getloadthuoctinh
    var Idproduct = Id;
    if (Idproduct == "") {
        Idproduct = "0";
    }
    getloadthuoctinh(Idproduct);
    getloadcauhinh(Idproduct);
    // end getloadthuoctinh

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

    // start getloadthuoctinh
    var Idproduct = Id;
    if (Idproduct == "") {
        Idproduct = "0";
    }
    getloadthuoctinh(Idproduct);
    getloadcauhinh(Idproduct);

    // end getloadthuoctinh
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

        TxtSeri: $("#TxtSeri").val(),
        TxtTenhang: $("#TxtTenhang").val(),

        TxtImage: $("#TxtImage").val(),
        TxtSeri: $("#TxtSeri").val(),
        TxtOrd: $("#TxtOrd").val(),
        TxtGiaban: $("#TxtGiaban").val(),
        TxtBaohanh: $("#TxtBaohanh").val(),
        TxtBaiviet: CKEDITOR.instances['TxtBaiviet'].getData(),
        TxtMota: CKEDITOR.instances['TxtMota'].getData(),
        CKActive: $("#CKActive").val(),
        Txtkhuyenmai_html: CKEDITOR.instances['Txtkhuyenmai_html'].getData(),
        TxtImage: $("#TxtImage").val(),
        TxtDescription: $("#TxtDescription").val(),
        TxtKeyword: $("#TxtKeyword").val()
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
        if (key == "TxtBaiviet" || key == "Txtkhuyenmai_html" || key == "TxtMota") {
            CKEDITOR.instances[key].setData(""); //set về rỗng
        }
    });
    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load photo main
   
    $("#TxtOrd").val("1");
    $("#CKActive").val("1");
    $("#TxtGiaban").val("0");
    $("#TxtBaohanh").val("12");

    $('#Selecthsx option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
    $('#Selectthuoctinh option').removeAttr('selected').filter('[value=""]').attr('selected', true);
    $('#SelectCategory option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
    $('#SelectPriority option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
    $('#Selecttinhtrang option').removeAttr('selected').filter('[value="1"]').attr('selected', true);

    // start getloadthuoctinh
    var Idproduct = "";
    if (Idproduct == "") {
        Idproduct = "0";
    }
    getloadthuoctinh(Idproduct);
    getloadcauhinh(Idproduct);
    $(".thuoctinhtab").addClass("hidden");
    $(".cauhinhtab").addClass("hidden");
    // end getloadthuoctinh

    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});

//load jaavscrip đầu vào
$("#update_paner").css("display", "none");


