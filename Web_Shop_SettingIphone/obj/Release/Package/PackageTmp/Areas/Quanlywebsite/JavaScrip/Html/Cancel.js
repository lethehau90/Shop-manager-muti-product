$(document).ready(function () {
    $('#Cancel').click(function () {
        var object = { //khai báo các giá trị xóa trống
            TxtTen: $("#TxtTen").val(),
            TxtTenEn: $("#TxtTenEn").val(),
            TxtHtmlcontent: $("#TxtHtmlcontent").val(),
            TxtHtmlcontentEn: $("#TxtHtmlcontentEn").val(),
            Txtimages: $("#Txtimages").val(),
            CKActive: ""
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtHtmlcontent" || key == "TxtHtmlcontentEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#CKActive").val("1");
        $("#TxtOrd").val("1");
        $('#SelectType option').removeAttr('selected').filter('[value=""]').attr('selected', true);
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});