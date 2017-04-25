$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),
            TxtLink: $("#TxtLink").val(),
            TxtOrd: $("#TxtOrd").val(),
            datepickerNgaytao: $("#datepickerNgaytao").val(),
            datepickerNgayhethan: $("#datepickerNgayhethan").val(),
            TxtContent: $("#TxtContent").val(),
            TxtContentEn: $("#TxtContentEn").val(),
            TxtImage: $("#TxtImage").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtContent" || key == "TxtContentEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#TxtOrd").val("1");
        $("#CKActive").val("1");
        $('#SelectPageId option').removeAttr('selected').filter('[value=""]').attr('selected', true);
        $('#SelectPosition option').removeAttr('selected').filter('[value=""]').attr('selected', true);
        $('#SelectTarget option').removeAttr('selected').filter('[value="_self"]').attr('selected', true);
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});