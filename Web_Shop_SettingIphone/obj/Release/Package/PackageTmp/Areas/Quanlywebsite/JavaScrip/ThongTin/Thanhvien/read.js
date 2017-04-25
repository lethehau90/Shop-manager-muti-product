function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/ThanhvienAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.id);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Hoten);

            $("#TxtTaikhoan").val(data.Taikhoan);
            $("#TxtMatkhau").val();
            $("#TxtHoten").val(data.Hoten);
            //thiet lap Ngaysinh
            if (data.Ngaysinh == null || data.Ngaysinh == "") {
                $("#datepickerNgaysinh").val("");
            }
            else {
                $("#datepickerNgaysinh").val(parseJsonDate(data.Ngaysinh));
            }
            $('#SelectGioitinh option').removeAttr('selected').filter('[value=' + data.Gioitinh + ']').attr('selected', true);
            $("#TxtDiachi").val(data.Diachi);
            $("#TxtSDT").val(data.SDT);
            $("#TxtEmail").val(data.Email);

            $("#CKActive").val(data.Actice);
           
            //check active
            if ($("#CKActive").val() == "true") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }
         
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
