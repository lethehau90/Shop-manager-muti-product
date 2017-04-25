$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),
            TxtOrd: $("#TxtOrd").val(),
            Date_event_start: $("#Date_event_start").val(),
            Date_event_end: $("#Date_event_end").val(),
            Txtcontent: $("#Txtcontent").val(),
            TxtcontentEn: $("#TxtcontentEn").val(),
            TxtPrice_event: $("#TxtPrice_event").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "Txtcontent" || key == "TxtcontentEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#TxtOrd").val("1");
        $("#CKActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});