function get_Copy(Id) {
    $.ajax({
        url: '/Quanlywebsite/CategotyproductdetailAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val("");

            //tiêu đề cập nhật theo tên
            $("span.Editcatelog").text("mới");

            $("#TxtName").val(data.Name);
            $("#TxtNameEn").val(data.NameEn);

            
            $("#TxtDonvi").val(data.Donvi);
            $("#TxtLuotdanhgia").val(data.Luotdanhgia);
            $("#TxtVideo").val(data.Video);

            $("#TxtTitle").val(data.Title);
            $("#TxtDescription").val(data.Description);
            $("#TxtKeyword").val(data.Keyword);

            //danh mục chọn
            $('#SelectPriority option').removeAttr('selected').filter('[value=' + data.Priority + ']').attr('selected', true);
            $('#SelectCategory option').removeAttr('selected').filter('[value=' + data.GroupNewsCatTag + ']').attr('selected', true);
            //disabled danh mục
            $("#SelectCategory").attr('disabled', 'disabled');

            $("#TxtIndex").val(data.Index);
            $("#TxtOrder").val(data.Order);

            $("#CKActive").val(data.Active);
            if ($("#CKActive").val() == "1") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }

            $("#TxtImage").val(data.Image);
            $("#TxtImage1").val(data.Image1);
            $("#TxtImage2").val(data.Image2);
            $("#TxtImage3").val(data.Image3);
            $("#TxtImage4").val(data.Image4);
            $("#TxtImage5").val(data.Image5);
           
            $("#TxtContent").val(data.Content);
            $("#TxtContentEn").val(data.ContentEn);

            ///set CKediter Content
            if (data.Detail == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDetail'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetail'].setData(data.Detail); //set dữ liệu Ckeditor
            }
           
            if (data.DetailEn == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDetailEn'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetailEn'].setData(data.DetailEn); //set dữ liệu Ckeditor
            }

            $("#TxtKhuyenmai").val(data.Khuyenmai);
            $("#TxtKhuyenmaiEn").val(data.KhuyenmaiEn);

            $("#TxtBaohanh").val(data.Baohanh);
            $("#TxtBaohanhEn").val(data.BaohanhEn);

            $("#TxtThongdiep").val(data.Thongdiep);
            $("#TxtThongdiepEn").val(data.ThongdiepEn);

            ///set CKediter DacDiemNoiBat
            if (data.DacDiemNoiBat == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDacDiemNoiBat'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDacDiemNoiBat'].setData(data.DacDiemNoiBat); //set dữ liệu Ckeditor
            }

            if (data.DacDiemNoiBatEn == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDacDiemNoiBatEn'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDacDiemNoiBatEn'].setData(data.DacDiemNoiBatEn); //set dữ liệu Ckeditor
            }

            $("#TxtSeri").val(data.Seri);

            $('#SelectStock option').removeAttr('selected').filter('[value=' + data.Stock + ']').attr('selected', true);
            $("#TxtNumber_Stock").val(data.Number_Stock);
            $("#CKVat").val(data.Vat);
           

            $("#CKVat").val(data.Vat);
            if ($("#CKVat").val() == "true") {
                $("#CKVat").prop('checked', true); // Checks it true
                $("#CKVat").attr('checked', 'checked');
                $("#CKVat").val("1");
            }
            else {
                $("#CKVat").prop('checked', false); // Checks it false
                $("#CKVat").removeAttr('checked');
                $("#CKVat").val("0");
            }


            $("#TxtGianhaphang").val(formatMoneyVND(data.Gianhaphang));
            $("#TxtGiaban").val(formatMoneyVND(data.Giaban));
            $("#TxtPhantramkhuyenmai").val(data.Phantramkhuyenmai);
            $("#TxtGiabankhuyenmai").val(formatMoneyVND(data.Giabankhuyenmai));

            if (data.DateStart_Event == null || data.DateStart_Event == "") {
                $("#datepickerDateStart_Event").val("");
            }
            else {
                $("#datepickerDateStart_Event").val(parseJsonDate(data.DateStart_Event));
            }

            if (data.DateEnd_Event == null || data.DateEnd_Event == "") {
                $("#datepickerDateEnd_Event").val("");
            }
            else {
                $("#datepickerDateEnd_Event").val(parseJsonDate(data.DateEnd_Event));
            }

            $("#TxtGiaban_Event").val(formatMoneyVND(data.Giaban_Event));
            $("#TxtContent_Event").val(data.Content_Event);
            $("#TxtContent_EventEn").val(data.Content_EventEn);

                // console.log(data);
                //load img envent main
                $("#imgShowScren").attr("src", data.Image); //lấy src trong data
                var img = $("#imgShowScren").attr("src"); // lấy giá trị
                if (img == "" || img == null) { //nếu null
                    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SliedesShow 1
                $("#imgShowScren1").attr("src", data.Image1); //lấy src trong data
                var img1 = $("#imgShowScren1").attr("src"); // lấy giá trị
                if (img1 == "" || img1 == null) { //nếu null
                    $("#imgShowScren1").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SiledeShow 2
                $("#imgShowScren2").attr("src", data.Image2); //lấy src trong data
                var img2 = $("#imgShowScren2").attr("src"); // lấy giá trị
                if (img2 == "" || img2 == null) { //nếu null
                    $("#imgShowScren2").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SliedesShow 3
                $("#imgShowScren3").attr("src", data.Image3); //lấy src trong data
                var img3 = $("#imgShowScren3").attr("src"); // lấy giá trị
                if (img3 == "" || img3 == null) { //nếu null
                    $("#imgShowScren3").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SlidesShow 4
                $("#imgShowScren4").attr("src", data.Image4); //lấy src trong data
                var img4 = $("#imgShowScren4").attr("src"); // lấy giá trị
                if (img4 == "" || img4 == null) { //nếu null
                    $("#imgShowScren4").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
                //load img envent SlidesShow 5
                $("#imgShowScren5").attr("src", data.Images5); //lấy src trong data
                var img5 = $("#imgShowScren5").attr("src"); // lấy giá trị
                if (img5 == "" || img5 == null) { //nếu null
                    $("#imgShowScren5").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }

                //load Video
                var video = $("#TxtVideo").val().split("?v=");
                var Id = video[1];
                var src = "https://youtube.com/embed/" + Id;
                $(".video iframe").attr("src", src);

                //var Uncheckthuonghieu = $("input[name='Ck_IDthuonghieu']:checkbox").not(':checked');


            //thuong hieu

                var htmlthuonghieu = data.IDthuonghieu.split(',');
                var checkthuonghieu = $("input[name='Ck_IDthuonghieu']");

                if (checkthuonghieu.length > 0) {
                    for (var j = 0 ; j < checkthuonghieu.length; j++) {
                        $(checkthuonghieu[j]).prop('checked', false); // Checks it false
                        $(checkthuonghieu[j]).removeAttr('checked');
                        for (var i = 0; i < htmlthuonghieu.length; i++) {
                            var thuonghieu = htmlthuonghieu[i];
                            if ($(checkthuonghieu[j]).val() == thuonghieu) {
                                $(checkthuonghieu[j]).prop('checked', true); // Checks it true
                                $(checkthuonghieu[j]).attr('checked', 'checked');
                            }
                        }
                    }
                }

            //mausac

                var htmlmausac = data.Mausac.split(',');
                var checkmausac = $("input[name='Ck_Mausac']");

                if (checkmausac.length > 0) {
                    for (var j = 0 ; j < checkmausac.length; j++)
                    {
                        $(checkmausac[j]).prop('checked', false); // Checks it false
                        $(checkmausac[j]).removeAttr('checked');
                        for (var i = 0; i < htmlmausac.length; i++) {
                            var mausac = htmlmausac[i];
                            if ($(checkmausac[j]).val() == mausac) {
                                $(checkmausac[j]).prop('checked', true); // Checks it true
                                $(checkmausac[j]).attr('checked', 'checked');
                            }
                        }
                    }
                }
   
            //Kich co

                var htmlkichthuoc = data.Kichthuoc.split(',');
                var checkkichthuoc = $("input[name='Ck_Kichthuoc']");

                if (checkkichthuoc.length > 0) {
                    for (var j = 0 ; j < checkkichthuoc.length; j++) {
                        $(checkkichthuoc[j]).prop('checked', false); // Checks it false
                        $(checkkichthuoc[j]).removeAttr('checked');
                        for (var i = 0; i < htmlkichthuoc.length; i++) {
                            var kichthuoc = htmlkichthuoc[i];
                            if ($(checkkichthuoc[j]).val() == kichthuoc) {
                                $(checkkichthuoc[j]).prop('checked', true); // Checks it true
                                $(checkkichthuoc[j]).attr('checked', 'checked');
                            }
                        }
                    }
                }

            //Nguồn sản xuất

                var htmlnguonsanxuat = data.NguonSanPham.split(',');
                var checknguonsanxuat = $("input[name='Ck_NguonSanPham']");

                if (checknguonsanxuat.length > 0) {
                    for (var j = 0 ; j < checknguonsanxuat.length; j++) {
                        $(checknguonsanxuat[j]).prop('checked', false); // Checks it false
                        $(checknguonsanxuat[j]).removeAttr('checked');
                        for (var i = 0; i < htmlnguonsanxuat.length; i++) {
                            var nguonsanxuat = htmlnguonsanxuat[i];
                            if ($(checknguonsanxuat[j]).val() == nguonsanxuat) {
                                $(checknguonsanxuat[j]).prop('checked', true); // Checks it true
                                $(checknguonsanxuat[j]).attr('checked', 'checked');
                            }
                        }
                    }
                }

            //san phẩm cùng loại

                var htmlsanphamcungloai = data.SanphamCungloai.split(',');
                var checksanphamcungloai = $("input[name='Ck_Sanphamcungloai']");

                if (checksanphamcungloai.length > 0) {
                    for (var j = 0 ; j < checksanphamcungloai.length; j++) {
                        $(checksanphamcungloai[j]).prop('checked', false); // Checks it false
                        $(checksanphamcungloai[j]).removeAttr('checked');
                        for (var i = 0; i < htmlsanphamcungloai.length; i++) {
                            var sanphamcungloai = htmlsanphamcungloai[i];
                            if ($(checksanphamcungloai[j]).val() == sanphamcungloai) {
                                $(checksanphamcungloai[j]).prop('checked', true); // Checks it true
                                $(checksanphamcungloai[j]).attr('checked', 'checked');
                            }
                        }
                    }
                }

                return false;
         
            
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
