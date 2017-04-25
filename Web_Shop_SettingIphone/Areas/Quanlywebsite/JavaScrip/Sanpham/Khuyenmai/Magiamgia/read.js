function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/MacodeKhuyenMaiAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.ID);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Macode);

            $("#TxtMacode").val(data.Macode);
            $("#TxtValueprice").val(data.Valueprice);

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
           // console.log(data);
            //load img sự kiện hình ảnh
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
