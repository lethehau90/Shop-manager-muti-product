$(document).ready(function () {
    $('#Cancel').click(function() {
        //$("#update_paner").css("display", "block");//hiển thị panner
        var object = {
            Name: $("#TxtName").val(),
            Image: $("#TxtImage").val(),
            TxtDetail: CKEDITOR.instances['TxtDetail'].getData(),
            Description: $("#TxtDescription").val(),
            Keyword: $("#TxtKeyword").val(),
            NameEn: $("#TxtNameEn").val(),
            TxtDetailEn: CKEDITOR.instances['TxtDetailEn'].getData()  //get dữ liệu ckeditor
        };

        $.each(object, function (key, item) { //process delete
            $("#Txt" + key).val("");
            if (key == "TxtDetail" || key == "TxtDetailEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#CKActive").val("1");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
        
    });
});