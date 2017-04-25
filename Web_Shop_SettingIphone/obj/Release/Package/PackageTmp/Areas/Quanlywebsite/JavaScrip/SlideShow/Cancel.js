$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner
        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),
            TxtDetail: $("#TxtDetail").val(),
            TxtDetailEn: $("#TxtDetailEn").val(),
            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val(),
            TxtImage: $("#TxtImage").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtDetail" || key == "TxtDetailEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#CKActive").val("1");
        $("#TxtOrd").val("1");
        $('#SelectTarget option').removeAttr('selected').filter('[value=""]').attr('selected', true);
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});