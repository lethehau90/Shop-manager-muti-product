function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/DientuMathangAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {

            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.Id);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Tenhang);
            $("#TxtTenhang").val(data.Tenhang);

            $("#TxtSeri").val(data.Seri);
            $("#TxtOrd").val(data.Ord);
            $("#TxtGiaban").val(data.Giaban)
            $("#TxtBaohanh").val(data.Baohanh);

            $("#TxtDescription").val(data.Description);
            $("#TxtKeyword").val(data.Keyword);

            //danh mục chọn
            $('#Selecthsx option').removeAttr('selected').filter('[value=' + data.Idnsx + ']').attr('selected', true);
            $('#Selectthuoctinh option').removeAttr('selected').filter('[value=' + data.Idthuoctinh + ']').attr('selected', true);
            $('#SelectCategory option').removeAttr('selected').filter('[value=' + data.Idmenu + ']').attr('selected', true);
            $('#SelectPriority option').removeAttr('selected').filter('[value=' + data.Priority + ']').attr('selected', true);
            $('#Selecttinhtrang option').removeAttr('selected').filter('[value=' + data.Tinhtrang + ']').attr('selected', true);
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
            $("#TxtImage").val(data.Img);

            ///set CKediter Content
            if (data.Mota == null) //trường hợp null
            {
                CKEDITOR.instances['TxtMota'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtMota'].setData(data.Mota); //set dữ liệu Ckeditor
            }

            if (data.Baiviet == null) //trường hợp null
            {
                CKEDITOR.instances['TxtBaiviet'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtBaiviet'].setData(data.Baiviet); //set dữ liệu Ckeditor
            }

            if (data.khuyenmai_html == null) //trường hợp null
            {
                CKEDITOR.instances['Txtkhuyenmai_html'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['Txtkhuyenmai_html'].setData(data.khuyenmai_html); //set dữ liệu Ckeditor
            }

            $("#TxtKhuyenmai").val(data.Khuyenmai);
            $("#TxtKhuyenmaiEn").val(data.KhuyenmaiEn);

            $("#TxtBaohanh").val(data.Baohanh);
            $("#TxtBaohanhEn").val(data.BaohanhEn);

            $("#TxtThongdiep").val(data.Thongdiep);
            $("#TxtThongdiepEn").val(data.ThongdiepEn);

            $("#TxtSeri").val(data.Seri);

            //cấu hình
            $("#TxtPhantramkmCH").val(0);

            // console.log(data);
            //load img envent main

            //    $("#imgShowScren").attr("src", data.Img); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
            $(".thuoctinhtab").removeClass("hidden"); //thuộc tính tab
            $(".cauhinhtab").removeClass("hidden"); //thuộc tính tab
            return false;


        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

function Get_Read_Tag(Tag) {
    $.ajax({
        url: '/Quanlywebsite/DientuMathangAdmin/Get_Read_Tag',
        type: "Post",
        dataType: 'json',
        data: { Tag: Tag },
        success: function (data) {

            $("#TxtId").val(data.Id);
            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Tenhang);

            $("#TxtImage").val(data.Img);

            $("#imgShowScren").attr("src", data.Img); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
            $(".thuoctinhtab").removeClass("hidden"); //thuộc tính tab
            $(".cauhinhtab").removeClass("hidden"); //thuộc tính tab
            return false;
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

//cấu hình trang chi tiết
function ClickEditCH(IdTag) {
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    $("body").addClass("loading");
    setTimeout(function () {
        $.ajax({
            url: "/Quanlywebsite/DientuChitiethinhAdmin/Get_Read_Idtag",
            data: { IdTag: IdTag },
            dataType: "json",
            type: "post",
            success: function (data) {
                $("#IdTagCH").val(data.IdTag);
                $("#TxtImageCH").val(data.Images);

                $("#TxtImage1CH").val(data.Images1),
                $("#TxtImage2CH").val(data.Images2),
                $("#TxtImage3CH").val(data.Images3),
                $("#TxtImage4CH").val(data.Images4),

                $("#TxtGiacuCH").val(data.Giacu);
                $("#TxtGiabanCH").val(data.Giaban);
                $("#TxtPhantramkmCH").val(data.Phantramkm);
                $("#TxtSoluongCH").val(data.Soluong);
                $('#SelectTinhtrangCH option').removeAttr('selected').filter('[value=' + data.Tinhtrang + ']').attr('selected', true);
                $('#SelectmausacCH option').removeAttr('selected').filter('[value=' + data.Idmau + ']').attr('selected', true);
                $('#SelectIddungluongCH option').removeAttr('selected').filter('[value=' + data.Iddungluong + ']').attr('selected', true);
                $("#TxtOrdCH").val(data.Ord);


                //active
                $("#CKActiveCH").val(data.Active);
                if ($("#CKActiveCH").val() == "true") {
                    $("#CKActiveCH").prop('checked', true); // Checks it true
                    $("#CKActiveCH").attr('checked', 'checked');
                    $("#CKActiveCH").val("1");
                }
                else {
                    $("#CKActiveCH").prop('checked', false); // Checks it false
                    $("#CKActiveCH").removeAttr('checked');
                    $("#CKActiveCH").val("0");
                }

                

                $("#imgShowScren").attr("src", data.Images); //lấy src trong data
                var img = $("#imgShowScren").attr("src"); // lấy giá trị
                if (img == "" || img == null) { //nếu null
                    $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
                }
            },
            error: function (ex) {
                alert(ex.error);
            }
        });
        $("body").removeClass("loading");
    }, 500);

};

//cấu hình trang thuộc tính
function ClickEditTT(IdTag) {
    //trượt tới vị trí panner
    $('html, body').animate({
        scrollTop: $("#update_paner").offset().top
    }, 500);
    $("body").addClass("loading");
    setTimeout(function () {
        $.ajax({
            url: "/Quanlywebsite/DientuThuoctinhAdmin/Get_Read_Idtag",
            data: { IdTag: IdTag },
            dataType: "json",
            type: "post",
            success: function (data) {
                $("#IdTagTT").val(data.IdTag);
                $("#TxtNameTT").val(data.Text);
                $("#TxtValueTT").val(data.Value);
                $("#TxtSoluongCH").val(data.Soluong);
                $("#TxtOrdTT").val(data.Ord);

                //active
                $("#CKActiveTT").val(data.Active);
                if ($("#CKActiveTT").val() == "true") {
                    $("#CKActiveTT").prop('checked', true); // Checks it true
                    $("#CKActiveTT").attr('checked', 'checked');
                    $("#CKActiveTT").val("1");
                }
                else {
                    $("#CKActiveTT").prop('checked', false); // Checks it false
                    $("#CKActiveTT").removeAttr('checked');
                    $("#CKActiveTT").val("0");
                }
            },
            error: function (ex) {
                alert(ex.error);
            }
        });
        $("body").removeClass("loading");
    }, 500);

};