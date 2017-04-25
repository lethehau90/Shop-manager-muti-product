$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtId: $("#TxtId").val(),
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),

            TxtTomtat: $("#TxtTomtat").val(),
            TxtNoidung: CKEDITOR.instances['TxtNoidung'].getData(),

            TxtContentEn: $("#TxtContentEn").val(),
            TxtDetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),

            TxtNguon: $("#TxtNguon").val(),

            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val(),

            TxtImage: $("#TxtImage").val(),
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtNoidung" || key == "TxtDetailEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });

        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định

        $("#TxtOrd").val("1");
        $("#CKActive").val("1");

        $('#SelectType option').removeAttr('selected').filter('[value="1"]').attr('selected', true);

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});