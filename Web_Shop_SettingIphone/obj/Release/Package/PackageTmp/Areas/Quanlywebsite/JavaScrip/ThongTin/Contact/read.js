function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/ContactAdmin/Get_Read',
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
            $('.Editcatelog').text(data.Name);

            $("#TxtName").val(data.Name);

            $("#TxtCompany").val(data.Company);
            $("#TxtAddress").val(data.Address);
            $("#TxtTel").val(data.Tel);
            $("#TxtMail").val(data.Mail);

            $("#CKActive").val(data.Active);
           ///set CKediter
            if (data.Detail == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDetail'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetail'].setData(data.Detail); //set dữ liệu Ckeditor
            }
           
            //check active
            if ($("#CKActive").val() == "1") {
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
