$(document).ready(function () {
    $('#Cancel').click(function () {
        var object = { //khai báo các giá trị xóa trống
            TxtTaikhoan: $("#TxtTaikhoan").val(),
            TxtMatkhau: $("#TxtMatkhau").val(),
            TxtHoten: $("#TxtHoten").val(),
            TxtDiachi: $("#TxtDiachi").val(),
            TxtSDT: $("#TxtSDT").val(),
            TxtEmail: $("#TxtEmail").val(),
      
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#datepickerNgaysinh").val("");
        $("#CKActive").val("false");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});