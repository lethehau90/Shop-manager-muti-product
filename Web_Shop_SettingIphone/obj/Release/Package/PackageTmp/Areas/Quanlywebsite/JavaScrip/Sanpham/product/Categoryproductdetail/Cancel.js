$(document).ready(function () {
    $('#Cancel').click(function () {
        $("span.Editcatelog").text("mới");
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtId: $("#TxtId").val(),
            TxtSeri: $("#TxtSeri").val(),
            TxtTenhang: $("#TxtTenhang").val(),

            TxtImage: $("#TxtImage").val(),
            TxtSeri: $("#TxtSeri").val(),
            TxtOrd: $("#TxtOrd").val,
            TxtGiaban: $("#TxtGiaban").val,
            TxtBaohanh: $("#TxtBaohanh").val,
            TxtBaiviet: CKEDITOR.instances['TxtBaiviet'].getData(),
            CKActive: $("#CKActive").val(),
            Txtkhuyenmai_html: CKEDITOR.instances['Txtkhuyenmai_html'].getData(),
            TxtImage: $("#TxtImage").val(),
            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val()
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtBaiviet" || key == "Txtkhuyenmai_html") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });



        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load photo main


        $("#TxtOrder").val("1");
        $("#CKActive").val("1");

        $('#Selecthsx option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
        $('#Selectthuoctinh option').removeAttr('selected').filter('[value=""]').attr('selected', true);
        $('#SelectCategory option').removeAttr('selected').filter('[value="1"]').attr('selected', true);

        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});