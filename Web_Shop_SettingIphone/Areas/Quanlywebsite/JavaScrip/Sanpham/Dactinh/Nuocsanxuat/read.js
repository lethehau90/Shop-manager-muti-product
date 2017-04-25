function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/NuocsanxuatAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.IDthuonghieu);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.TenNuocsanxuat);

            $("#TxtTenNuocsanxuat").val(data.TenNuocsanxuat);
            $("#TxtImage").val(data.Logo);
            //active
            $("#CKActive").val(data.Active);
            if ($("#CKActive").val() == "true") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
                $("#CKActive").val("1");
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
                $("#CKActive").val("0");
            }
            $("#TxtVitri").val(data.Vitri);
            ///set CKediter mota
            $("#TxtTenNuocsanxuat_En").val(data.TenNuocsanxuat_En);
           // console.log(data);
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Logo); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
