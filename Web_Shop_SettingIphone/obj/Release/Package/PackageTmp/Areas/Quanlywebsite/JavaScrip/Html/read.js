function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/CodeHtmlAdmin/Get_Read',
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
            $('.Editcatelog').text(data.Ten);

            $("#TxtTen").val(data.Ten);
            $("#TxtTenEn").val(data.TenEn);
            $("#CKActive").val(data.Active);
            $("#TxtOrd").val(data.Ord);
           ///set CKediter
            if (data.Html_content == null ) //trường hợp null
            {
                CKEDITOR.instances['TxtHtmlcontent'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtHtmlcontent'].setData(data.Html_content); //set dữ liệu Ckeditor
            }
            if (data.Html_contentEn == null) //set về rỗng
            {
                CKEDITOR.instances['TxtHtmlcontentEn'].setData("");
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtHtmlcontentEn'].setData(data.Html_contentEn); //set dữ liệu Ckeditor
            }
            
            //SelectType    
            $('#SelectType option').removeAttr('selected').filter('[value=' + data.type + ']').attr('selected', true);
            //check active
            if ($("#CKActive").val() == "1") {
                $("#CKActive").prop('checked', true); // Checks it true
                $("#CKActive").attr('checked', 'checked');
            }
            else {
                $("#CKActive").prop('checked', false); // Checks it false
                $("#CKActive").removeAttr('checked');
            }
            $("#Txtimages").val(data.images);
            //check active
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.images); //lấy src trong data
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
