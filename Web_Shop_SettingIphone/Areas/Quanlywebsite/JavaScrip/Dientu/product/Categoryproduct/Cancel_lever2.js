﻿$(document).ready(function () {
    $('#Cancel_lever').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtlevelName: $("#TxtlevelName").val(),
            Txtlevelcontent: $("#Txtlevelcontent").val(),
            TxtlevelOrd: $("#TxtlevelOrd").val(),

            TxtlevelLogogroup: $("#TxtlevelLogogroup").val(),
            TxtlevelDescription:$("#TxtlevelDescription").val(),
            TxtlevelKeyword: $("#TxtlevelKeyword").val(),
            CKTxtlevelActive: "",
            CKTxtlevelPriority: ""

        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#TxtlevelOrd").val("1");
        $("#CKTxtlevelActive").val("1");
        $("#CKTxtlevelPriority").val("0");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});

$(document).ready(function () {
    $('#Cancel_add').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtaddName: $("#TxtaddName").val(),
            Txtaddcontent: $("#Txtaddcontent").val(),
            TxtaddOrd: $("#TxtaddOrd").val(),
            TxtaddDescription: $("#TxtaddDescription").val(),
            TxtaddKeyword: $("#TxtaddKeyword").val(),
            TxtaddLogogroup: $("#TxtaddLogogroup").val(),
            CKaddActive: "",
            CKaddPriority: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#TxtaddOrd").val("1");
        $("#CKaddActive").val("1");
        $("#CKaddPriority").val("0");

        $('#Selectlevel option').removeAttr('selected').filter('[value=""]').attr('selected', true);

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner_add").offset().top
        }, 500);
        return false;
    });
});