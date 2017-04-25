$(document).ready(function () {
   
    $("#Save").click(function () { // khi nhấn lệnh lưu
        $(".error").remove(); //xóa class báo lỗi vailform inut
        //xóa thông tin header
        var khoangdau = $("#TxtKhoangdau").val();
        var khoangcuoi = $("#TxtKhoangcuoi").val();

        if (khoangdau >= khoangcuoi)
        {
            var html = "<span  class='error'> Khoảng đầu không thể lớn hơn hoặc bằng khoảng cuối</span>";
            $(".TxtKhoangdau").append(html);
            return false;
        }


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
        TxtKhoangdau: $("#TxtKhoangdau").val(),
        TxtKhoangcuoi: $("#TxtKhoangcuoi").val(),
        TxtOrd: $("#TxtOrd").val(),
        CKActive: ""
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
    });
    $("#TxtOrd").val("1");
    $("#CKActive").val("1");
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});

