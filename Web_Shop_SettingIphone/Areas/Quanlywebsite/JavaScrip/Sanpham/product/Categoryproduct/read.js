function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/CategotyproductAdmin/Get_Read',
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
            $("#TxtNameEn").val(data.NameEn);

            $("#Txtcontent").val(data.content);
            $("#TxtcontentEn").val(data.contentEn);

            $("#TxtDescription").val(data.Description);
            $("#TxtKeyword").val(data.Keyword);

            $("#TxtOrd").val(data.Ord);
            $("#CKActive").val(data.Active);
            $("#CKPriority").val(data.Priority);

            $('#Selectlevel option').removeAttr('selected').filter('[value=' + data.Level + ']').attr('selected', true);

            $("#TxtLogogroup").val(data.Logogroup);

            //active
            if ($("#CKActive").val() == "1") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }

            //active
            if ($("#CKPriority").val() == "1") {
                $("#CKPriority").prop('checked', true); // Checks it true
                $("#CKPriority").attr('checked', 'checked');
            }
            else {
                $("#CKPriority").prop('checked', false); // Checks it false
                $("#CKPriority").removeAttr('checked');
            }

            //console.log(data);

            // disble select danh mục

           
                $("#Selectlevel").attr('disabled', 'disabled');
           
           
         //  ddlchaChange(data.Level);

            $("#Selectlevelmuti").addClass("hidden");
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Logogroup); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/Images/no-Image.jpg"); // load ảnh mặt định
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
