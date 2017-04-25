function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/MausacAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.IDmau);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Tenmau);

            $("#TxtTenmau").val(data.Tenmau);
            $("#TxtImage").val(data.Hinhanh);
         
            $("#TxtOrd").val(data.Ord);

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

            $("#TxtTenmauEn").val(data.TenmauEn);
           // console.log(data);
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Hinhanh); //lấy src trong data
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
