$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),
            Txtcontent: $("#Txtcontent").val(),
            TxtcontentEn: $("#TxtcontentEn").val(),
            TxtOrd: $("#TxtOrd").val(),

            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val(),
            TxtLogogroup: $("#TxtLogogroup").val(),
            CKActive: "",
            CKPriority: ""

        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#TxtOrd").val("1");
        $("#CKActive").val("1");
        $("#CKPriority").val("0");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });

    //xử lý cho cancel thêm

    $('#Cancel_add').click(function () {
        $("#update_paner_add").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtaddName: $("#TxtaddName").val(),
            TxtaddNameEn: $("#TxtaddNameEn").val(),
            Txtaddcontent: $("#Txtaddcontent").val(),
            TxtaddcontentEn: $("#TxtaddcontentEn").val(),
            TxtaddOrd: $("#TxtaddOrd").val(),

            TxtaddDescription: $("#TxtaddDescription").val(),
            TxtaddKeyword: $("#TxtaddKeyword").val(),
            TxtaddLogogroup: $("#TxtaddLogogroup").val(),
            CKaddActive: "",
            CKaddPriority: ""

        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
        });
        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
        $("#TxtaddOrd").val("1");
        $("#CKaddActive").val("1");
        $("#CKaddPriority").val("0");
        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner_add").offset().top
        }, 500);
        return false;
    });
});