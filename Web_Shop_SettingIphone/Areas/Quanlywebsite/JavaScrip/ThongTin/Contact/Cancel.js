$(document).ready(function () {
    $('#Cancel').click(function () {
        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtCompany: $("#TxtCompany").val(),
            TxtAddress: $("#TxtAddress").val(),
            TxtTel: $("#TxtTel").val(),
            TxtMail: $("#TxtMail").val(),


            TxtDetail: $("#TxtDetail").val(),
      
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtDetail") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#CKActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});