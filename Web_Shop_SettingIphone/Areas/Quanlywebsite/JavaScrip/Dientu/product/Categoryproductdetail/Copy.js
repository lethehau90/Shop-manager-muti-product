function get_Copy(Id) {
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
            $("#TxtId").val("");

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

            $("#imgShowScren").attr("src", data.Img); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
            $(".thuoctinhtab").addClass("hidden"); //thuộc tính tab
            $(".cauhinhtab").addClass("hidden"); //thuộc tính tab
            return false;
         
            
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
