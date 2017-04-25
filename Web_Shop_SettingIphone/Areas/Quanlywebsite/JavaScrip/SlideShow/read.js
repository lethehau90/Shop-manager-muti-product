function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/SlideShowAdmin/Get_Read',
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

           ///set CKediter
            if (data.Detail == null || data.Detail == "") //trường hợp null
            {
                CKEDITOR.instances['TxtDetail'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetail'].setData(data.Detail); //set dữ liệu Ckeditor
            }

            //DetailEn
            if (data.DetailEn == null || data.DetailEn == "") //set về rỗng
            {
                CKEDITOR.instances['TxtDetailEn'].setData("");
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetailEn'].setData(data.DetailEn); //set dữ liệu Ckeditor
            }

            $("#TxtDescription").val(data.Description);
            $("#TxtKeyword").val(data.Keyword);
            
            //SelectTarget   
           // $('#SelectType option').removeAttr('selected').filter('[value=' + data.Type + ']').attr('selected', true);
            $('#SelectTarget option').removeAttr('selected').filter('[value=' + data.Target + ']').attr('selected', true);
           
            //check active
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

            $("#TxtImage").val(data.Image);
            $("#TxtOrd").val(data.Ord);
            //check active
            //load img sự kiện hình ảnh

            $("#imgShowScren").attr("src", data.Image); //lấy src trong data
            var img = $("#imgShowScren").attr("src"); // lấy giá trị
            if (img == "" || img == null) { //nếu null
                $("#imgShowScren").attr("src", "/images/no-image.jpg"); // load ảnh mặt định
            }
            console.log(data);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
