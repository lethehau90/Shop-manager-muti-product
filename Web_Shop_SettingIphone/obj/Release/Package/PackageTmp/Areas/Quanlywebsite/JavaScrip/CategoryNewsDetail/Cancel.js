$(document).ready(function () {
    $('#Cancel').click(function () {
        $("span.Editcatelog").text("mới");
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtId: $("#TxtId").val(),
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),

            TxtContent: $("#TxtContent").val(),
            TxtDetail: CKEDITOR.instances['TxtDetail'].getData(),

            TxtContentEn: $("#TxtContentEn").val(),
            TxtDetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),

            TxtNguon: $("#TxtNguon").val(),

            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val(),

            TxtImage: $("#TxtImage").val(),
            TxtImage1: $("#TxtImage1").val(),
            TxtImage2: $("#TxtImage2").val(),
            TxtImage3: $("#TxtImage3").val(),
            TxtImage4: $("#TxtImage4").val(),
            TxtImage5: $("#TxtImage5").val(),
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtDetail" || key == "TxtDetailEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });

        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load photo main
        $("#imgShowScren1").attr("src", "/images/no-image.jpg");// load photo SlidesShow 1
        $("#imgShowScren2").attr("src", "/images/no-image.jpg");// load photo SlidesShow 2 
        $("#imgShowScren3").attr("src", "/images/no-image.jpg");// load photo SlidesShow 3
        $("#imgShowScren4").attr("src", "/images/no-image.jpg");// load photo SlidesShow 4
        $("#imgShowScren5").attr("src", "/images/no-image.jpg");// load photo SlidesShow 5

        $("#Txtord").val("1");
        $("#CKActive").val("1");

        $('#SelectPriority option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
        $('#SelectCategory option').removeAttr('selected').filter('[value=""]').attr('selected', true);

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});