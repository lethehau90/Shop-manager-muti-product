$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtMacode: $("#TxtMacode").val(),
            TxtMacodeEn: $("#TxtMacodeEn").val(),
            TxtValueprice: $("#TxtValueprice").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#TxtValueprice").val("");
        $("#CKActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});