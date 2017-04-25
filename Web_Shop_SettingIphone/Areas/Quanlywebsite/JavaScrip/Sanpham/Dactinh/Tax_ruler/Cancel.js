$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),
            TxtProvince: $("#TxtProvince").val(),
            TxtGia: $("#TxtGia").val(),
            TxtOrd: $("#TxtOrd").val(),
            //file tax rule
            TxtFile_tax: $("#TxtFile_tax").val(),
            TxtDescription: $("#TxtDescription").val(),
            TxtDescriptionEn: $("#TxtDescriptionEn").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtDescription" || key == "TxtDescriptionEn") {
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