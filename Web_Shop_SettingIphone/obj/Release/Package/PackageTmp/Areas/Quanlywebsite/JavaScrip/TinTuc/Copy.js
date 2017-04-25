function get_Copy(Id) {
    $.ajax({
        url: '/Quanlywebsite/TinTucAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
           
            /* Before serialize */
            for (instance in CKEDITOR.instances) {
                CKEDITOR.instances[instance].updateElement();
            }
            $("#TxtId").val("");

            //tiêu đề cập nhật theo tên
            $('.Editcatelog').text("mới");

            $("#TxtName").val(data.Name);
            $("#TxtNameEn").val(data.NameEn);
           
            $("#TxtTomtat").val(data.Tomtat);

            ///set CKediter Content
            if (data.Noidung == null) //trường hợp null
            {
                CKEDITOR.instances['TxtNoidung'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtNoidung'].setData(data.Noidung); //set dữ liệu Ckeditor
            }

            

            $("#TxtContentEn").val(data.ContentEn);

            if (data.DetailEn == null) //trường hợp null
            {
                CKEDITOR.instances['TxtDetailEn'].setData(""); //set về rỗng
            }
            else //ngược lại
            {
                CKEDITOR.instances['TxtDetailEn'].setData(data.DetailEn); //set dữ liệu Ckeditor
            }
                $('#SelectType option').removeAttr('selected').filter('[value=' + data.Type + ']').attr('selected', true);

                $("#TxtOrd").val(data.Ord);

                $("#TxtNguon").val(data.Nguon);


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

                $("#TxtDescription").val(data.Description);

                $("#TxtKeyword").val(data.Keyword);


                $("#TxtImage").val(data.Hinhanh);


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
