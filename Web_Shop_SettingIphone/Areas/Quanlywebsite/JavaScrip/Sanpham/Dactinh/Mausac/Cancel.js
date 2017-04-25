$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtTenmau: $("#TxtTenmau").val(),
            TxtTenmauEn: $("#TxtTenmauEn").val(),
            TxtOrd: $("#TxtOrd").val(),
            TxtImage: $("#TxtImage").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
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
});