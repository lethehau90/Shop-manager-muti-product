$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),
            TxtGia: $("#TxtGia").val(),
            TxtOrd: $("#TxtOrd").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#TxtOrd").val("1");
        $("#TxtGia").val("0");
        $("#CKActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});