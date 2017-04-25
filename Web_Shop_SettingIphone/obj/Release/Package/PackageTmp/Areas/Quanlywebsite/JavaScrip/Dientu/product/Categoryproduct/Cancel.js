$(document).ready(function () {
    $('#Cancel').click(function () {
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtName: $("#TxtName").val(),
            Txtcontent: $("#Txtcontent").val(),
            TxtOrd: $("#TxtOrd").val(),
            TxtLogogroup: $("#TxtLogogroup").val(),
            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val(),
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
            Txtaddcontent: $("#Txtaddcontent").val(),
            TxtaddOrd: $("#TxtaddOrd").val(),
            TxtaddLogogroup: $("#TxtaddLogogroup").val(),
            TxtaddDescription: $("#TxtaddDescription").val(),
            TxtaddKeyword: $("#TxtaddKeyword").val(),
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