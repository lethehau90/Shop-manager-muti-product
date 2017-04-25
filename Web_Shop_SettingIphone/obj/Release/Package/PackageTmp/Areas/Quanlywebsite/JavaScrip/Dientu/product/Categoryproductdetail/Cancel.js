$(document).ready(function () {
    $('#Cancel').click(function () {
        $("span.Editcatelog").text("mới");
        $("#update_paner").css("display", "block");//hiển thị panner

        var object = { //khai báo các giá trị xóa trống
            TxtId: $("#TxtId").val(),
            TxtName: $("#TxtName").val(),
            TxtNameEn: $("#TxtNameEn").val(),

            TxtIDthuonghieu: $("#TxtIDthuonghieu").val(),
            TxtNguonSanPham: $("#TxtNguonSanPham").val(),
            TxtMausac: $("#TxtMausac").val(),
            TxtKichthuoc: $("#TxtKichthuoc").val(),
            TxtDonvi: $("#TxtDonvi").val(),
            TxtLuotdanhgia: $("#TxtLuotdanhgia").val(),
            TxtVideo: $("#TxtVideo").val(),

            TxtTitle: $("#TxtTitle").val(),
            TxtDescription: $("#TxtDescription").val(),
            TxtKeyword: $("#TxtKeyword").val(),

            TxtPriority: $("#TxtPriority").val(),
            TxtIndex: $("#TxtIndex").val(),
            //TxtOrder: $("#TxtOrder").val(),
            CKActive: $("#CKActive").val(),

            TxtImage: $("#TxtImage").val(),
            TxtImage1: $("#TxtImage1").val(),
            TxtImage2: $("#TxtImage2").val(),
            TxtImage3: $("#TxtImage3").val(),
            TxtImage4: $("#TxtImage4").val(),
            TxtImage5: $("#TxtImage5").val(),

            TxtContent: $("#TxtContent").val(),
            TxtContentEn: $("#TxtContentEn").val(),

            TxtDetail: CKEDITOR.instances['TxtDetail'].getData(),
            TxtDetailEn: CKEDITOR.instances['TxtDetailEn'].getData(),

            TxtKhuyenmai: $("#TxtKhuyenmai").val(),
            TxtKhuyenmaiEn: $("#TxtKhuyenmaiEn").val(),

            TxtBaohanh: $("#TxtBaohanh").val(),
            TxtBaohanhEn: $("#TxtBaohanhEn").val(),

            TxtDacDiemNoiBat: CKEDITOR.instances['TxtDacDiemNoiBat'].getData(),
            TxtDacDiemNoiBatEn: CKEDITOR.instances['TxtDacDiemNoiBatEn'].getData(),

            TxtThongdiep: $("#TxtThongdiep").val(),
            TxtThongdiepEn: $("#TxtThongdiepEn").val(),

            TxtSeri: $("#TxtSeri").val(),
            TxtLuotxem: $("#TxtLuotxem").val(),
            TxtSoluongmua: $("#TxtSoluongmua").val(),

            //giá trị
            TxtStock: $("#TxtStock").val(),
            TxtNumber_Stock: $("#TxtNumber_Stock").val(),
            TxtGianhaphang: $("#TxtGianhaphang").val(),
            TxtGiaban: $("#TxtGiaban").val(),
            TxtPhantramkhuyenmai: $("#TxtPhantramkhuyenmai").val(),
            TxtGiabankhuyenmai: $("#TxtGiabankhuyenmai").val(),
            TxtDateStart_Event: $("#TxtDateStart_Event").val(),
           
            TxtContent_Event: $("#TxtContent_Event").val(),
            TxtContent_EventEn: $("#TxtContent_EventEn").val(),
        };

        $.each(object, function (key, item) { //process delete
            $("#" + key).val("");
            if (key == "TxtDetail" || key == "TxtDetailEn" || key == "TxtDacDiemNoiBat" || key == "TxtDacDiemNoiBatEn") {
                CKEDITOR.instances[key].setData(""); //set về rỗng
            }
        });

        $('#datepickerDateStart_Event').val("");
        $('#datepickerDateEnd_Event').val("");

        $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load photo main
        $("#imgShowScren1").attr("src", "/images/no-image.jpg");// load photo SlidesShow 1
        $("#imgShowScren2").attr("src", "/images/no-image.jpg");// load photo SlidesShow 2 
        $("#imgShowScren3").attr("src", "/images/no-image.jpg");// load photo SlidesShow 3
        $("#imgShowScren4").attr("src", "/images/no-image.jpg");// load photo SlidesShow 4
        $("#imgShowScren5").attr("src", "/images/no-image.jpg");// load photo SlidesShow 5

        $("#TxtOrder").val("1");
        $("#CKActive").val("1");
        $("#CKVat").val("1");

        $('#SelectPriority option').removeAttr('selected').filter('[value="1"]').attr('selected', true);
        $('#SelectCategory option').removeAttr('selected').filter('[value=""]').attr('selected', true);
        $('#SelectStock option').removeAttr('selected').filter('[value="1"]').attr('selected', true);

        //thuong hieu

        var checkthuonghieu = $("input[name='Ck_IDthuonghieu']");

        if (checkthuonghieu.length > 0) {
            for (var j = 0 ; j < checkthuonghieu.length; j++) {
                $(checkthuonghieu[j]).prop('checked', false); // Checks it false
                $(checkthuonghieu[j]).removeAttr('checked');
            }
        }

        //mausac

        var checkmausac = $("input[name='Ck_Mausac']");

        if (checkmausac.length > 0) {
            for (var j = 0 ; j < checkmausac.length; j++) {
                $(checkmausac[j]).prop('checked', false); // Checks it false
                $(checkmausac[j]).removeAttr('checked');
            }
        }

        //Kich co

        var checkkichthuoc = $("input[name='Ck_Kichthuoc']");

        if (checkkichthuoc.length > 0) {
            for (var j = 0 ; j < checkkichthuoc.length; j++) {
                $(checkkichthuoc[j]).prop('checked', false); // Checks it false
                $(checkkichthuoc[j]).removeAttr('checked');
            }
        }

        //Nguồn sản xuất

        var checknguonsanxuat = $("input[name='Ck_NguonSanPham']");

        if (checknguonsanxuat.length > 0) {
            for (var j = 0 ; j < checknguonsanxuat.length; j++) {
                $(checknguonsanxuat[j]).prop('checked', false); // Checks it false
                $(checknguonsanxuat[j]).removeAttr('checked');
            }
        }

        //Nguồn sản xuất

        var checksanphamcungloai = $("input[name='Ck_Sanphamcungloai']");

        if (checksanphamcungloai.length > 0) {
            for (var j = 0 ; j < checksanphamcungloai.length; j++) {
                $(checksanphamcungloai[j]).prop('checked', false); // Checks it false
                $(checksanphamcungloai[j]).removeAttr('checked');
            }
        }



        //trượt tới vị trí panner
        $('html, body').animate({
            scrollTop: $("#update_paner").offset().top
        }, 500);
        return false;
    });
});