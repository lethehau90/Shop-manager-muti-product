function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/NewInformationAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {

            $("#TxtId").val(data.Id);

            $("#TxtName").val(data.Name);
            $("#TxtImage").val(data.Image);

            if (data.Detail == null) //set về rỗng
            {
                CKEDITOR.instances['TxtDetail'].setData("");
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetail'].setData(data.Detail); //set dữ liệu Ckeditor
            }
            console.log(data);
            //active
            $("#CKActive").val(data.Active);
            //check active
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

            $("#TxtDescription").val(data.Description);
            $("#TxtKeyword").val(data.Keyword);

            $("#TxtIndex").val(data.Index); //chỉ mục lục

            $("#TxtNameEn").val(data.NameEn);

            if (data.DetailEn == null) //set về rỗng
            {
                CKEDITOR.instances['TxtDetailEn'].setData("");
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetailEn'].setData(data.DetailEn); //set dữ liệu Ckeditor
            }

            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Image); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img==null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
            console.log(data);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

