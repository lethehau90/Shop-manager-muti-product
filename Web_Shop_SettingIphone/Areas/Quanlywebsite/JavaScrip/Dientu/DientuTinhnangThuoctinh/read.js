function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/DientuTinhnangAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val(data.Idthuoctinh);

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text(data.Thuoctinh);

            $("#TxtName").val(data.Thuoctinh);

            $("#Txtcontent").val(data.Content);

            $("#TxtOrd").val(data.Ord);
            $("#CKActive").val(data.Active);
            if (data.Idtinhang == "0")
            {
                data.Idtinhang = null;
            }
            $('#Selectlevel option').removeAttr('selected').filter('[value=' + data.Idtinhang + ']').attr('selected', true);

            //active
            if ($("#CKActive").val() == "true") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }

            //console.log(data);

            // disble select danh mục

           
                $("#Selectlevel").attr('disabled', 'disabled');
           
           
         //  ddlchaChange(data.Level);

            $("#Selectlevelmuti").addClass("hidden");
            //load img sự kiện hình ảnh

            //$("#imgShowScren").attr("src", data.Logogroup); //lấy src trong data
            //var img = $("#imgShowScren").attr("src"); // lấy giá trị
            //if (img == "" || img == null) { //nếu null
            //    $("#imgShowScren").attr("src", "/Images/no-Image.jpg"); // load ảnh mặt định
            //}
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
