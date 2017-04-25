$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtTenthuonghieu: $("#TxtTenthuonghieu").val(),
            TxtTenthuonghieu_En: $("#TxtTenthuonghieu_En").val(),
            TxtUrl: $("#TxtUrl").val(),
            TxtVitri: $("#TxtVitri").val(),
            Txtmota: $("#Txtmota").val(),
            Txtmota_En: $("#Txtmota_En").val(),
            TxtImage: $("#TxtImage").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "Txtmota" || key == "Txtmota_En") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#TxtVitri").val("1");
        $("#CKActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});