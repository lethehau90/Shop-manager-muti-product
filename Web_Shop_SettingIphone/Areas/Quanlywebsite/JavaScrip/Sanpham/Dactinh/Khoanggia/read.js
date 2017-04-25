function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/khoanggiaAdmin/Get_Read',
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
            $('.Editcatelog').text(data.Khoangdau + "--" + data.Khoangcuoi);

            $("#TxtKhoangdau").val(data.Khoangdau);
            $("#TxtKhoangcuoi").val(data.Khoangcuoi);
         
            $("#TxtOrd").val(data.Vitri);

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
        
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
