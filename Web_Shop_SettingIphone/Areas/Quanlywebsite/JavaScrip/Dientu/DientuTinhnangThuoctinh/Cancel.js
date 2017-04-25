$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            Txtcontent: $("#Txtcontent").val(),
            TxtOrd: $("#TxtOrd").val(),
            CKActive: "",

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

    //xử lý cho cancel thêm

    $('#Cancel_add').click(function () {
        $("#update_paner_add").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtaddName: $("#TxtaddName").val(),
            Txtaddcontent: $("#Txtaddcontent").val(),
            TxtaddOrd: $("#TxtaddOrd").val(),
            CKaddActive: "",
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#TxtaddOrd").val("1");
        $("#CKaddActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner_add").offset().top
        }, 500);
        return false;
    });
});