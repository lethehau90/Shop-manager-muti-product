﻿$(document).ready(function () {
   
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
        TxtHovaten: $("#TxtHovaten").val(),
        TxtThuonghieu: $("#TxtThuonghieu").val(),
        TxtDongmay: $("#TxtDongmay").val(),
        TxtSoseri: $("#TxtSoseri").val(),
        TxtSodienthoai: $("#TxtSodienthoai").val(),
        TxtImages1: $(".TxtImages1").text(),
        TxtImages2: $(".TxtImages2").text(),
        TxtGiaban: $("#TxtGiaban").val(),
        TxtNoidungsuachua: $("#TxtNoidungsuachua").val(),

        CKActive: ""
    };

    $.each(object, function (key, item) { //process delete
        $("#" + key).val("");
        if (key == "TxtNoidungsuachua") {
            CKEDITOR.instances[key].setData(""); //set về rỗng
        }
    });
    $("#CKActive").val("1");
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    return false;
});
